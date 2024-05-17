
using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Classes.Entites
{
    public class Siparis : BaseClass
    {

        public int UserID { get; set; }
        public ICollection<SiparislerMenuler> SiparislerMenuler { get; set; }
        public ICollection<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
        public AppUser AppUser { get; set; }
    }
}
