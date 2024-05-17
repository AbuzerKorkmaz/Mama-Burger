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

        public SiparisController(ApplicationDbContext service, UserManager<AppUser> _userManager)

        {
            _service = service;
            userManager = _userManager;

            siparisOlusturDTO = new();
            siparisOlusturDTO.Menuler = _service.Menuler.Where(x => x.AktifMi == true).ToList();
            siparisOlusturDTO.ExtraMalzemeler = _service.ExtraMalzemeler.ToList();
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

            //Menu menu = _service.Menuler.Where(m => m.MenuID == siparisGonderDTO.MenuID).SingleOrDefault();
            //if (menu == null)
            //{

            //    throw new Exception("Menü bulunamadı.");
            //}

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
                //Fiyat = siparisGonderDTO.Fiyat,
                UserID = siparisGonderDTO.UserID,
                AktifMi = true
            };

            _service.Sepettekiler.Add(sepet);
            _service.SaveChanges();

            siparisGonderDTO.Sepettekiler = _service.Sepettekiler.Where(x => x.UserID == siparisGonderDTO.UserID).Include(x => x.Menu).ToList();

            if (siparisGonderDTO.Sepettekiler.Count > 1 && siparisGonderDTO.ekleme == 1)
            {

                return PartialView("_SepetTemizlensinMi", siparisGonderDTO);
            }

            return PartialView("_SiparisListesi", siparisGonderDTO);
        }




        public IActionResult SepetiOnayla(int id)
        {
            SepetiOnaylaDTO sepetiOnaylaDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserID == id).ToList()
            };
            return View(sepetiOnaylaDTO);
        }

        public IActionResult SiparisOnayla(int id)
        {
            Siparis siparis = new()
            {
                UserID = id
            };

            _service.Siparisler.Add(siparis);
            _service.SaveChanges();

            List<Sepet> sepetIcerigi = _service.Sepettekiler.Where(x => x.UserID == id).ToList();
            foreach (Sepet item in sepetIcerigi)
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
                    _service.SaveChanges();
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
                sepet.Fiyat = (sepet.Fiyat / sepet.Adet) * (sepet.Adet - 1);
                sepet.Adet--;
                _service.Sepettekiler.Update(sepet);
                _service.SaveChanges();
            }
            else
            {
                _service.Sepettekiler.Remove(sepet);
                _service.SaveChanges();

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
            _service.SaveChanges();
            SiparisGonderDTO siparisGonderDTO = new();
            siparisGonderDTO.Sepettekiler = _service.Sepettekiler.Where(x => x.AktifMi == true).ToList();
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }
        public IActionResult Siparis()
        {
            var userIDClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            int userID = int.Parse(userIDClaim.Value);

            List<Siparis> siparis = _service.Siparisler.Where(x => x.UserID == userID).Include(x => x.SiparislerMenuler).ToList();

            return View(siparis);
        }

        [HttpPost]
        public IActionResult SepetTemizle(SepetTemizleDTO sepetTemizleDTO)
        {
            int sonEklenenId = _service.Sepettekiler.Max(x => x.ID);
            foreach (Sepet item in _service.Sepettekiler.Where(x => x.UserID == sepetTemizleDTO.userId && x.ID != sonEklenenId).ToList())
            {
                _service.Sepettekiler.Remove(item);
                _service.SaveChanges();
            }
            SiparisGonderDTO siparisGonderDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserID == sepetTemizleDTO.userId).Include(x => x.Menu).ToList()
            };
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }
        [HttpPost]
        public IActionResult SepetYukle(SepetTemizleDTO sepetTemizleDTO)
        {
            SiparisGonderDTO siparisGonderDTO = new()
            {
                Sepettekiler = _service.Sepettekiler.Where(x => x.UserID == sepetTemizleDTO.userId).ToList()
            };
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }


        public IActionResult _SiparisListesi(int userId)
        {
            // Kullanıcının sepetindeki ürünleri al
            var sepetUrunleri = _service.Sepettekiler.Where(x => x.UserID == userId).Include(x => x.Menu).ToList();

            // SiparisGonderDTO nesnesi oluştur
            var siparisGonderDTO = new SiparisGonderDTO
            {
                Sepettekiler = sepetUrunleri
            };

            return PartialView("_SiparisListesi", siparisGonderDTO);
        }

        [HttpPost]
        public IActionResult _SiparisListesi(SiparisGonderDTO siparisGonderDTO)
        {
            // SiparisGonderDTO içindeki userId'yi kullanarak kullanıcının sepetini güncelle
            var sepetUrunleri = _service.Sepettekiler.Where(x => x.UserID == siparisGonderDTO.UserID).Include(x => x.Menu).ToList();
            siparisGonderDTO.Sepettekiler = sepetUrunleri;

            return PartialView("_SiparisListesi", siparisGonderDTO);
        }

        [HttpPost]
        public IActionResult SepeteEkle(int urunId, int adet, int boyut)
        {
            // Ürünü sepete eklemek için gerekli verileri toplayın

            // Veritabanından ürün bilgisini alın (örneğin, urunId kullanılarak)

            // Ürünü sepete ekleyin
            Sepet sepetItem = new Sepet
            {
                UrunID = urunId,
                Adet = adet,
                Boyut =(Boyut)boyut,
                // Diğer gerekli bilgileri de ekleyin
            };

            //_service.Sepet.Add(sepetItem);
            _service.SaveChanges();

            // Sepete eklendikten sonra kullanıcıyı uygun bir sayfaya yönlendirin
            return RedirectToAction("SiparisOlustur");
        }


    }
}
