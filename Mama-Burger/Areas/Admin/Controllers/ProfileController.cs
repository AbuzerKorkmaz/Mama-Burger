
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MamaBurger.DTOsVMs.DTOs;
using MamaBurger.Validations;
using MamaBurger.Classes.Entites;
using System.Security.Claims;
using MamaBurger.Data;

namespace MamaBurger.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        ApplicationDbContext _service;

        public ProfileController(ApplicationDbContext service)
        {
            _service = service;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            var admin=_service.Users.Where(x=>x.UserName=="admin").FirstOrDefault();

            UpdateUserDTO updateUserDTO = new UpdateUserDTO()
            {
                Ad=admin.UserName,
                Email=admin.Email,
                PhoneNumber=admin.PhoneNumber,             
            };

            return View(updateUserDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(UpdateUserDTO updateUserDTO)
        {
            UpdateUserDTOValidator validationRules = new UpdateUserDTOValidator();
            var valid = validationRules.Validate(updateUserDTO);
            if (!valid.IsValid)
            {
                var admin = _service.Users.Where(x => x.UserName == "admin").FirstOrDefault();

                admin.Email= updateUserDTO.Email;
                admin.PhoneNumber= updateUserDTO.PhoneNumber;
                _service.Users.Update(admin);

                return RedirectToAction("Settings");
            }

            foreach (var item in valid.Errors)
            {
                ModelState.AddModelError("Hata", item.ErrorMessage);
            }
            return View();
        }
    }
}
