
using FluentValidation;
using MamaBurger.DTOsVMs.DTOs.ExtraMalzemeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Validations.ExtraMalzeme
{
    public class CreateExtraMalzemeDTOValidator : AbstractValidator<CreateExtraMalzemeDTO>
    {
        public CreateExtraMalzemeDTOValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Ad alani bos gecilemez!");
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat alani bos gecilemez!");
        }
    }
}
