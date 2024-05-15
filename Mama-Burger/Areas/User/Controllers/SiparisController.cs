using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MamaBurger.DTOsVMs.DTOs;
using MamaBurger.Classes.Entites;
using MamaBurger.Classes.Enums;
using System.Security.Claims;
using MamaBurger.Data;
using Microsoft.EntityFrameworkCore;

namespace MamaBurger.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Musteri,Admin")]
    public class SiparisController : Controller
    {
        ApplicationDbContext _service;
        SiparisOlusturDTO siparisOlusturDTO;    
        private readonly UserManager<AppUser> userManager;

        public SiparisController(ApplicationDbContext service,UserManager<AppUser> _userManager)

        {
            _service=service;
            userManager = _userManager;

            siparisOlusturDTO = new();
            siparisOlusturDTO.Menuler = _service.Menuler.Where(x => x.AktifMi == true).ToList();
            siparisOlusturDTO.ExtraMalzemeler= _service.ExtraMalzemeler.Select(x=>x).ToList();
            this.userManager = _userManager;
        }
       
        public IActionResult SiparisOlustur()
        {
            return View(siparisOlusturDTO);
        }

        [HttpPost]
        public IActionResult SiparisGonder(SiparisGonderDTO siparisGonderDTO)
        {
			Menu menu = _service.Menuler.Find(siparisGonderDTO.MenuID);

			siparisGonderDTO.MenuAdi = menu.Adi;
			siparisGonderDTO.Fiyat = menu.Fiyat;
			if (siparisGonderDTO.Boyut == Boyut.Büyük) siparisGonderDTO.Fiyat *= 1.4M;
			else if (siparisGonderDTO.Boyut == Boyut.Orta) siparisGonderDTO.Fiyat *= 1.2M;
			siparisGonderDTO.Fiyat *= siparisGonderDTO.Adet;
            Sepet sepet = new Sepet()
            {
                MenuID = siparisGonderDTO.MenuID,
                Adet = siparisGonderDTO.Adet,
                Boyut = siparisGonderDTO.Boyut,
                Fiyat = siparisGonderDTO.Fiyat,
                UserId=siparisGonderDTO.UserID,
                AktifMi = true
            };
            
            _service.Sepettekiler.Add(sepet);
            siparisGonderDTO.Sepettekiler = _service.Sepettekiler.Where(x => x.UserId == siparisGonderDTO.UserID).Include(x => x.Menu).ToList();

            if(siparisGonderDTO.Sepettekiler.Count > 1 && siparisGonderDTO.ekleme==1)
            {
                return PartialView("_SepetTemizlensinMi", siparisGonderDTO);
            }

            return PartialView("_SiparisListesi",siparisGonderDTO);
        }

        public IActionResult SepetiOnayla(string id)
        {
            SepetiOnaylaDTO sepetiOnaylaDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserId == id).ToList()
			};
            return View(sepetiOnaylaDTO);
        }
        
        public IActionResult SiparisOnayla(string id)
        {
            Siparis siparis = new()
            {
                UserID = id
			};
            _service.Siparisler.Add(siparis);
			List<Sepet> sepetIcerigi = _service.Sepettekiler.Where(x => x.UserId == id).ToList();
            foreach(Sepet item in sepetIcerigi)
            {
                if (item.MenuID != null)
                {
                    SiparislerMenuler siparislerMenu = new SiparislerMenuler()
                    {
                        SiparisID = siparis.ID,
                        MenuID = (int)item.MenuID,
                        Boyut = item.Boyut,
                        Adet = item.Adet,
                        TotalFiyat = item.Fiyat
                    };
                    _service.SiparislerMenuler.Add(siparislerMenu);
                    _service.Sepettekiler.Remove(item);
                }
            }


            return RedirectToAction("SiparisOlustur");
        }
        [HttpPost]
        public IActionResult SepettenSil(SepettenSilDTO sepettenSilDTO)
        {
            Sepet sepet = _service.Sepettekiler.Where(x => x.ID == sepettenSilDTO.sepetID).SingleOrDefault();
            if (sepet.Adet > 1)
            {
                sepet.Fiyat = (sepet.Fiyat/sepet.Adet)*(sepet.Adet-1);
                sepet.Adet--;
                _service.Sepettekiler.Update(sepet);
            }
            else
            {
                _service.Sepettekiler.Remove(sepet);
            }
            SiparisGonderDTO siparisGonderDTO = new();
			siparisGonderDTO.Sepettekiler = _service.Sepettekiler.Where(x => x.AktifMi == true).ToList();

			return PartialView("_SiparisListesi", siparisGonderDTO);
		}
        [HttpPost]
        public IActionResult AdetArttır(SepettenSilDTO sepettenSilDTO)
        {
            Sepet sepet = _service.Sepettekiler.Where(x => x.ID == sepettenSilDTO.sepetID).SingleOrDefault();
			sepet.Fiyat = (sepet.Fiyat / sepet.Adet) * (sepet.Adet + 1);
			sepet.Adet++;
            _service.Sepettekiler.Update(sepet);
            SiparisGonderDTO siparisGonderDTO = new();
			siparisGonderDTO.Sepettekiler = _service.Sepettekiler.Where(x => x.AktifMi == true).ToList();
			return PartialView("_SiparisListesi", siparisGonderDTO);
		}
     public IActionResult Siparis()
        {
            var userIDClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            string userID = userIDClaim.Value;

            List<Siparis> siparis = _service.Siparisler.Where(x=>x.UserID==userID).Include(x => x.SiparislerMenuler).ToList();

            return View(siparis);
        }

        [HttpPost]
        public IActionResult SepetTemizle(SepetTemizleDTO sepetTemizleDTO)
        {
            int sonEklenenId = _service.Sepettekiler.Max(x => x.ID);
            foreach(Sepet item in _service.Sepettekiler.Where(x=>x.UserId==sepetTemizleDTO.userId && x.ID!= sonEklenenId).ToList())
            {
                _service.Sepettekiler.Remove(item);
            }
            SiparisGonderDTO siparisGonderDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserId == sepetTemizleDTO.userId).Include(x => x.Menu).ToList()
            };
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }
        [HttpPost]
        public IActionResult SepetYukle(SepetTemizleDTO sepetTemizleDTO)
        {
            SiparisGonderDTO siparisGonderDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserId == sepetTemizleDTO.userId).ToList()
            };
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }

    }
}
