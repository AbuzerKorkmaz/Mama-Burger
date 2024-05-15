using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DTOsVMs.DTOs
{
    public class CreateMenuDTO
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public IFormFile Image { get; set; }
    }
}
