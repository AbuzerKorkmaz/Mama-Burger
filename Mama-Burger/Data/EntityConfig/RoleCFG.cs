using Mama_Burger.Classes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mama_Burger.Data.EntityConfig
{
    public class RoleCFG : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                 new AppRole() { Name = "Musteri", NormalizedName = "MUSTERI",Id=1,ConcurrencyStamp=Guid.NewGuid().ToString() },
                        new AppRole() { Name = "Admin", NormalizedName = "ADMIN",Id=2, ConcurrencyStamp = Guid.NewGuid().ToString() }
                        );
        }
    }
}
