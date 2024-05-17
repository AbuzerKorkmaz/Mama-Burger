
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MamaBurger.DTOsVMs.DTOs;
using MamaBurger.Validations.MenuValidate;
using MamaBurger.Classes.Entites;
using MamaBurger.Data;

namespace MamaBurger.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        ApplicationDbContext _service;

        public MenuController(ApplicationDbContext service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.Menuler.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuDTO createMenu)
        {
            CreateMenuDTOValidator validator = new();
            var valid = validator.Validate(createMenu);
            if (valid.IsValid)
            {
                Menu menu = new Menu();
                menu.Adi = createMenu.Adi;
                menu.Fiyat = createMenu.Fiyat;
                menu.AktifMi = true;
                menu.OlusturmaZamani = DateTime.Now;

                if (createMenu.Image != null && IsImage(createMenu.Image.ContentType))
                {
                    Guid guid = Guid.NewGuid();
                    string dosyaAdi = guid.ToString();
                    dosyaAdi += createMenu.Image.FileName;
                    string dosyaYolu = "wwwroot/MenuResimleri/";
                    menu.Fotograf = dosyaAdi;

                    FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                    createMenu.Image.CopyTo(fs);
                    fs.Close();
                }

                _service.Menuler.Add(menu);
                _service.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);

                }
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            Menu updateMenu = _service.Menuler.Find(id);

            UpdateMenuDTO updateMenuDTO = new UpdateMenuDTO()
            {
                Adi = updateMenu.Adi,
                Fiyat = updateMenu.Fiyat
            };

            return View(updateMenuDTO);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMenuDTO updatedMenuDto)
        {
            CreateMenuDTOValidator validator = new();
            var valid = validator.Validate(updatedMenuDto);
            if (valid.IsValid)
            {
                Menu updateMenu = _service.Menuler.Find(updatedMenuDto.ID);
                updateMenu.Adi= updatedMenuDto.Adi;
                updateMenu.Fiyat= updatedMenuDto.Fiyat;

                if (updatedMenuDto.Image != null && IsImage(updatedMenuDto.Image.ContentType))
                {
                    Guid guid = Guid.NewGuid();
                    string dosyaAdi = guid.ToString();
                    dosyaAdi += updatedMenuDto.Image.FileName;
                    string dosyaYolu = "wwwroot/MenuResimleri/";
                    updateMenu.Fotograf = dosyaAdi;

                    FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                    updatedMenuDto.Image.CopyTo(fs);
                    fs.Close();
                }

                _service.Menuler.Update(updateMenu);
                _service.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("MenuHata", item.ErrorMessage);
                }
                return View();
            }


        }
        public IActionResult Delete(int id)
        {
            Menu deleteMenu = _service.Menuler.Find(id);
            return View(deleteMenu);
        }
        [HttpPost]
        public IActionResult Delete(Menu menu)
        {
            Menu deleteMenu = _service.Menuler.Find(menu.ID);
            deleteMenu.AktifMi = false;
            _service.Menuler.Update(deleteMenu);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool IsImage(string contentType)
        {
            string[] allowedContentTypes = { "image/jpeg", "image/png", "image/gif" };
            return allowedContentTypes.Contains(contentType);
        }
    }
}
