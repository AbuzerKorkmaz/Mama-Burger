
using MamaBurger.Classes.Entites;
using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DTOsVMs.DTOs
{
    public class SiparisOlusturDTO
    {
        public SiparisOlusturDTO()
        {
            Menuler = new();
            ExtraMalzemeler = new();
        }
        public List<Menu> Menuler { get; set; }
        public Boyut Boyut { get; set; }
        public List<ExtraMalzeme> ExtraMalzemeler { get; set; } 
    }
}
