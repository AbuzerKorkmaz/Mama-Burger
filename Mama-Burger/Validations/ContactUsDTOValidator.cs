﻿using FluentValidation;
using MamaBurger.DTOsVMs.DTOs;
using MamaBurger.DTOsVMs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Validations
{
    public class ContactUsDTOValidator : AbstractValidator<ContactUsDTO>
    {
        public ContactUsDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen ad ve soyad bilgisi giriniz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email bilgisi giriniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen konu bilgisi giriniz!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen mesajınızı  giriniz!");
        }
    }
}
