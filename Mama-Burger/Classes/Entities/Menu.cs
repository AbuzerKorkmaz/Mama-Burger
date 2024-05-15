using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Classes.Entites
{
    public class Menu : BaseClass
    {
 
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public string Fotograf { get; set; }
        public ICollection<SiparislerMenuler> SiparislerMenuler { get; set; }
        public ICollection<Sepet> SepettekiMenuler { get; set; }
    }
}
