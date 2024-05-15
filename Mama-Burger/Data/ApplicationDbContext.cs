using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje.DATA.Entities;
using System.Reflection;

namespace Mama_Burger.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        }
    }
}
