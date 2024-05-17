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
            builder.HasData(new Menu() { ID =1, Adi = "Beefy Burgers", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 2,Adi = "Burger Bizz", Fiyat = 270, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID =3, Adi = "Burger Boys", Fiyat = 120, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 4,Adi = "Crackles Burger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 5,Adi = "Bull Burgers", Fiyat = 200, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 6, Adi = "Rocket Burgers", Fiyat = 200, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 7, Adi = "Smokin Burger", Fiyat = 300, AktifMi = true, OlusturmaZamani = DateTime.Now },
                        new Menu() { ID = 8, Adi = "Delish Burger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now }


                        );

            builder.Property(x => x.Adi).IsRequired().HasMaxLength(30);

        }
    }
}
