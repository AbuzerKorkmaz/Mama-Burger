using FluentValidation;
using MamaBurger.DTOsVMs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Validations.MenuValidate
{
    public class CreateMenuDTOValidator :AbstractValidator<CreateMenuDTO>
    {
        public CreateMenuDTOValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Ad alani bos gecilemez!");
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat alani bos gecilemez!");

        }
    }
}
