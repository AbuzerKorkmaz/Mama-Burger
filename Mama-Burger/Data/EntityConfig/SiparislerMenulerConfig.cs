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
    public class SiparislerMenulerConfig : IEntityTypeConfiguration<SiparislerMenuler>
    {
        public void Configure(EntityTypeBuilder<SiparislerMenuler> builder)
        {
            builder.HasOne(x=>x.Menu)
                .WithMany(x=>x.SiparislerMenuler)
                .HasForeignKey(x=>x.MenuID);
            builder.HasOne(x => x.Siparis)
                .WithMany(x => x.SiparislerMenuler)
                .HasForeignKey(x => x.SiparisID);
            builder.HasKey("ID");
        }
    }
}
