using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaBurger.Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DAL.EntityConfig
{
    public class MenuConfig : BaseConfig<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);
            builder.HasData(new Menu() { ID =1, Adi = "Classic", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 2,Adi = "CheeseBurger", Fiyat = 170, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID =3, Adi = "Acılı Burger", Fiyat = 120, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 4,Adi = "DoubleBurger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 5,Adi = "Tavuk Burger", Fiyat = 100, AktifMi = true, OlusturmaZamani = DateTime.Now });

            builder.Property(x => x.Adi).IsRequired().HasMaxLength(30);

        }
    }
}
