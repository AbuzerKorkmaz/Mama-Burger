using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MamaBurger.Classes.Entites;
using System.Reflection;
using Mama_Burger.Classes.Entities;
using Microsoft.AspNetCore.Identity;

namespace MamaBurger.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<ExtraMalzeme> ExtraMalzemeler { get; set; }
        public DbSet<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
        public DbSet<SiparislerMenuler> SiparislerMenuler { get; set; }
        public DbSet<Sepet> Sepettekiler { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            //rol 1 user 1 vereceğiz ;
            IdentityUserRole<int> identityUserRole = new IdentityUserRole<int>();
            identityUserRole.UserId = 1;
            identityUserRole.RoleId = 2;

            builder.Entity<IdentityUserRole<int>>(x => x.HasData(identityUserRole));
        }
    }
}
