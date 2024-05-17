using Microsoft.AspNetCore.Identity;
using MamaBurger.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.Classes.Entites
{
    public class AppUser : IdentityUser<int>
    {
 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int ConfirmCode { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public ICollection<Siparis> Siparisler { get; set; }
        public ICollection<Sepet> SepettekiMenuler { get; set; }
    }
}
