using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MamaBurger.Classes.Entites;
using MamaBurger.Data;
using Mama_Burger.Classes.Entities;

namespace MamaBurger.Models.SeedData
{
    public static class DataSeeder
    {
        public static async void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();


                context.Database.Migrate();

                if (!context.Roles.Any())
                {
                    await context.Roles.AddRangeAsync(
                        new AppRole() { Name = "Musteri", NormalizedName = "MUSTERI" },
                        new AppRole() { Name = "Admin", NormalizedName = "ADMIN" }
                        );
                }
                await context.SaveChangesAsync();

                if (!context.Users.Any())
                {
                    PasswordHasher<AppUser> password = new();
                    AppUser appUser = new AppUser() { Ad = "Admin", Soyad = "Admin", UserName = "admin", NormalizedUserName = "ADMIN", DogumTarihi = new DateTime(1990, 01, 01), Cinsiyet = Classes.Enums.Cinsiyet.Erkek, Email = "admin@admin.com", NormalizedEmail = "ADMIN@ADMIN.COM", EmailConfirmed = true };

                    context.Users.AddRange(appUser);
                    var hashed = password.HashPassword(appUser, "Admin12.");
                    appUser.PasswordHash = hashed;

                    //var userStore = new UserStore<AppUser,AppRole,ApplicationDbContext>(context);
                    //await userStore.AddToRoleAsync(appUser, "ADMIN");
                }
                await context.SaveChangesAsync();
                if (!context.Menuler.Any())
                {

                    using (HttpClient client = new HttpClient())
                    {
                        List<string> menuUrlList = MenuUrl();
                        //List<byte[]> imageBytes = new List<byte[]>();
                        //foreach (string item in menuUrlList)
                        //{
                        //    imageBytes.Add(await client.GetByteArrayAsync(item));
                        //}
                        List<Menu> menuler = new List<Menu>()
                    {
                        new Menu() {Adi = "Classic",Fiyat = 150,AktifMi = true,OlusturmaZamani = DateTime.Now },
                        new Menu() {Adi = "CheeseBurger",Fiyat = 170, AktifMi = true,OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "Acılı Burger",Fiyat = 120,  AktifMi = true, OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "DoubleBurger",Fiyat = 150,  AktifMi = true, OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "Tavuk Burger",Fiyat = 100, AktifMi = true,OlusturmaZamani = DateTime.Now},

                    };
                        context.Menuler.AddRange(menuler);
                    }

                }
                context.SaveChanges();

                if (!context.ExtraMalzemeler.Any())
                {
                    List<ExtraMalzeme> extras = new List<ExtraMalzeme>()
                    {
                        new ExtraMalzeme()
                        {
                            Adi="Ketçap", Fiyat=5 ,Cesit=Classes.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 

                        new ExtraMalzeme()
                        {
                            Adi="Mayonez", Fiyat=5 ,Cesit=Classes.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 

                        new ExtraMalzeme()
                        {
                            Adi="Ranch Sos", Fiyat=5 ,Cesit=Classes.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 
                        new ExtraMalzeme()
                        {
                            Adi="Barbekü Sos", Fiyat=5 ,Cesit=Classes.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                         new ExtraMalzeme()
                        {
                            Adi="Sufle", Fiyat=5 ,Cesit=Classes.Enums.Cesit.Tatlı,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Patates Kızartması", Fiyat=45 ,Cesit=Classes.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Mac&Cheese Balls", Fiyat=60 ,Cesit=Classes.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Mozarella Sticks", Fiyat=70 ,Cesit=Classes.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Dondurma", Fiyat=20 ,Cesit=Classes.Enums.Cesit.Tatlı,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                    };
                    context.ExtraMalzemeler.AddRange(extras);
                }
                context.SaveChanges();


            }
        }
        private static List<string> MenuUrl()
        {
            List<string> menuUrl = new List<string>();

            string bigKing = "https://www.burgerking.com.tr/cmsfiles/products/big-king-menu.png?v=305";
            menuUrl.Add(bigKing);

            string whooper = "https://d3vkdqr0qjxhag.cloudfront.net/burger-king/whopper_menu_2b7dbd274f.webp";
            menuUrl.Add(whooper);

            string kingChicken = "https://www.burgerking.com.tr/cmsfiles/products/king-chicken-menu.png?v=305";
            menuUrl.Add(kingChicken);

            string bigMac = "https://www.diyetkolik.com/site_media/media/nutrition_images/66A245CD-4EA3-4F2D-B498-0E1EA75D1EB4.jpeg";
            menuUrl.Add(bigMac);

            string tavukBurger = "https://www.burgerking.com.tr/cmsfiles/products/tavukburger-menu.png?v=305";
            menuUrl.Add(tavukBurger);

            return menuUrl;
        }
    }
}
