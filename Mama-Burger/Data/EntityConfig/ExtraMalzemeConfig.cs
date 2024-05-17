using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MamaBurger.Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DAL.EntityConfig
{
    public class ExtraMalzemeConfig : BaseConfig<ExtraMalzeme>
    {
        public override void Configure(EntityTypeBuilder<ExtraMalzeme> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Adi).IsRequired().HasMaxLength(65);

            builder.Property(x => x.Fiyat).IsRequired();

            builder.HasData(new ExtraMalzeme()
            {
                ID=1,
                Adi = "Ketçap",
                Fiyat = 5,
                Cesit = Classes.Enums.Cesit.Sos,
                AktifMi = true,
                OlusturmaZamani = DateTime.Now
            },

                        new ExtraMalzeme()
                        {
                            ID = 2,
                            Adi = "Mayonez",
                            Fiyat = 5,
                            Cesit = Classes.Enums.Cesit.Sos,
                            AktifMi = true,
                            OlusturmaZamani = DateTime.Now
                        },

                        new ExtraMalzeme()
                        {
                            ID = 3,
                            Adi = "Ranch Sos",
                            Fiyat = 5,
                            Cesit = Classes.Enums.Cesit.Sos,
                            AktifMi = true,
                            OlusturmaZamani = DateTime.Now
                        },
                        new ExtraMalzeme()
                        {
                            ID = 4,
                            Adi = "Barbekü Sos",
                            Fiyat = 5,
                            Cesit = Classes.Enums.Cesit.Sos,
                            AktifMi = true,
                            OlusturmaZamani = DateTime.Now
                        },
                         new ExtraMalzeme()
                         {
                             ID =6,
                             Adi = "Sufle",
                             Fiyat = 5,
                             Cesit = Classes.Enums.Cesit.Tatlı,
                             AktifMi = true,
                             OlusturmaZamani = DateTime.Now
                         },
                          new ExtraMalzeme()
                          {
                              ID =7,
                              Adi = "Patates Kızartması",
                              Fiyat = 45,
                              Cesit = Classes.Enums.Cesit.Aperatif,
                              AktifMi = true,
                              OlusturmaZamani = DateTime.Now
                          },
                          new ExtraMalzeme()
                          {
                              ID =8,
                              Adi = "Mac&Cheese Balls",
                              Fiyat = 60,
                              Cesit = Classes.Enums.Cesit.Aperatif,
                              AktifMi = true,
                              OlusturmaZamani = DateTime.Now
                          },
                          new ExtraMalzeme()
                          {
                              ID =9,
                              Adi = "Mozarella Sticks",
                              Fiyat = 70,
                              Cesit = Classes.Enums.Cesit.Aperatif,
                              AktifMi = true,
                              OlusturmaZamani = DateTime.Now
                          },
                          new ExtraMalzeme()
                          {
                              ID=10,
                              Adi = "Dondurma",
                              Fiyat = 20,
                              Cesit = Classes.Enums.Cesit.Tatlı,
                              AktifMi = true,
                              OlusturmaZamani = DateTime.Now
                          });
        }
    }
}
