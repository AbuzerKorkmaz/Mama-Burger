using FluentValidation;
using MamaBurger.DTOsVMs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Validations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı girmelisiniz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
        }
    }
}
