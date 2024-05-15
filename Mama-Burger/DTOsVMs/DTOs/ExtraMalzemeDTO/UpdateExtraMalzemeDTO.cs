using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MamaBurger.Classes.Entites;
using MamaBurger.Classes.Enums;

namespace MamaBurger.DTOsVMs.DTOs.ExtraMalzemeDTO
{
    public class UpdateExtraMalzemeDTO : CreateExtraMalzemeDTO
    {
        public int ID { get; set; }
    }
}
