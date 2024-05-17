using MamaBurger.Classes.Entites;
using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DTOsVMs.DTOs
{
    public class SiparisGonderDTO
    {
        public SiparisGonderDTO()
        {
            Sepettekiler = new();
        }
        public int MenuID { get; set; }
        public Boyut Boyut { get; set; }
        public string MenuAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public List<Sepet> Sepettekiler { get; set; }
        public int UserID { get; set; }
        public int ekleme { get; set; }
        public int MalzemeID { get; set; }
        public int Sos1ID { get; set; }
        public int Sos2ID { get;set; }
    }
}
