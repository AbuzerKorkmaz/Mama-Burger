
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
        public ICollection<Menu> Menuler { get; set; }
        public Boyut Boyut { get; set; }
        public ICollection<ExtraMalzeme> ExtraMalzemeler { get; set; } 
    }
}
