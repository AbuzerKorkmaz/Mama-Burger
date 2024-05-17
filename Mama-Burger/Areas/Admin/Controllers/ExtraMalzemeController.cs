
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MamaBurger.DTOsVMs.DTOs.ExtraMalzemeDTO;
using MamaBurger.Validations.ExtraMalzeme;
using MamaBurger.Classes.Entites;
using MamaBurger.Data;

namespace MamaBurger.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExtraMalzemeController : Controller
    {
        ApplicationDbContext _service;

        public ExtraMalzemeController(ApplicationDbContext service)
        {
            _service = service;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.ExtraMalzemeler.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateExtraMalzemeDTO createExtraMalzeme)
        {
            CreateExtraMalzemeDTOValidator validator = new();
            var valid = validator.Validate(createExtraMalzeme);
            if (valid.IsValid)
            {
                ExtraMalzeme extraMalzeme = new ExtraMalzeme();
                extraMalzeme.Adi = createExtraMalzeme.Adi;
                extraMalzeme.Fiyat= createExtraMalzeme.Fiyat;
                extraMalzeme.OlusturmaZamani=DateTime.Now;
                extraMalzeme.AktifMi = true;
                extraMalzeme.Cesit=createExtraMalzeme.Cesit;

                _service.ExtraMalzemeler.Add(extraMalzeme);
                _service.SaveChanges();
                return RedirectToAction("Index","ExtraMalzeme");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ExtraMalzemeHata", item.ErrorMessage);
                }
                return View();
            }

        }
        public IActionResult Edit(int id)
        {
            ExtraMalzeme updateExtraMalzeme = _service.ExtraMalzemeler.Find(id);
            UpdateExtraMalzemeDTO uExtraMalzemeDTO = new UpdateExtraMalzemeDTO();
            uExtraMalzemeDTO.Adi = updateExtraMalzeme.Adi;
            uExtraMalzemeDTO.Fiyat = updateExtraMalzeme.Fiyat;
            uExtraMalzemeDTO.Cesit = uExtraMalzemeDTO.Cesit;
            return View(uExtraMalzemeDTO);
        }

        [HttpPost]
        public IActionResult Edit(UpdateExtraMalzemeDTO updateExtraMalzemeDTO)
        {
            CreateExtraMalzemeDTOValidator validator = new();
            var valid = validator.Validate(updateExtraMalzemeDTO);
            if (valid.IsValid)
            {
                ExtraMalzeme extraMalzeme = _service.ExtraMalzemeler.Find(updateExtraMalzemeDTO.ID);
                extraMalzeme.Adi = updateExtraMalzemeDTO.Adi;
                extraMalzeme.Fiyat = updateExtraMalzemeDTO.Fiyat;
                extraMalzeme.Cesit = updateExtraMalzemeDTO.Cesit;
                extraMalzeme.GuncellemeZamani=DateTime.Now;

                _service.ExtraMalzemeler.Update(extraMalzeme);
                _service.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ExtraMalzemeHata", item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {

            ExtraMalzeme deleteExtraMalzeme = _service.ExtraMalzemeler.Find(id);
            deleteExtraMalzeme.AktifMi = false;
            deleteExtraMalzeme.SilinmeZamani = DateTime.Now;
            _service.ExtraMalzemeler.Update(deleteExtraMalzeme);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
