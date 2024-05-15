using MamaBurger.Classes.Entites;
using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DTOsVMs.DTOs.ExtraMalzemeDTO
{
    public class CreateExtraMalzemeDTO
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public Cesit Cesit { get; set; }
    }
}
