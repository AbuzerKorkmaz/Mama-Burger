using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Classes.Entites
{
    public class ExtraMalzeme : BaseClass
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public ICollection<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
		public ICollection<Sepet> SepettekiExtraMalzemeler { get; set; }
        public Cesit Cesit { get; set; }
	}
}
