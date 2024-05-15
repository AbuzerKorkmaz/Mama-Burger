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
        }
    }
}
