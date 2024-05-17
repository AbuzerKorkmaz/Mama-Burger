﻿// <auto-generated />
using System;
using MamaBurger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mama_Burger.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MamaBurger.Classes.Entites.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cinsiyet")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConfirmCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Ad = "Cevdet",
                            Cinsiyet = 0,
                            ConcurrencyStamp = "66c653fb-e1ee-4727-8e39-8d5a23ad3ced",
                            ConfirmCode = 0,
                            DogumTarihi = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cevdet@deneme.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CEVDET@DENEME.COM",
                            NormalizedUserName = "CEVDET@DENEME.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJqGiFjqx0txht09RRw2puPwQBsNnMJN/JaTw9rTei4yqnzc5/C0OmpSgIh6mMl2lg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "77a61323-017e-496d-8a5c-aea0d89f9b55",
                            Soyad = "Heredot",
                            TwoFactorEnabled = false,
                            UserName = "cevdet@deneme.com"
                        });
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.ExtraMalzeme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("Cesit")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("GuncellemeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturmaZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("ExtraMalzemeler");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Adi = "Ketçap",
                            AktifMi = true,
                            Cesit = 0,
                            Fiyat = 5m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2938)
                        },
                        new
                        {
                            ID = 2,
                            Adi = "Mayonez",
                            AktifMi = true,
                            Cesit = 0,
                            Fiyat = 5m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2953)
                        },
                        new
                        {
                            ID = 3,
                            Adi = "Ranch Sos",
                            AktifMi = true,
                            Cesit = 0,
                            Fiyat = 5m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2955)
                        },
                        new
                        {
                            ID = 4,
                            Adi = "Barbekü Sos",
                            AktifMi = true,
                            Cesit = 0,
                            Fiyat = 5m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2956)
                        },
                        new
                        {
                            ID = 6,
                            Adi = "Sufle",
                            AktifMi = true,
                            Cesit = 2,
                            Fiyat = 5m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2957)
                        },
                        new
                        {
                            ID = 7,
                            Adi = "Patates Kızartması",
                            AktifMi = true,
                            Cesit = 1,
                            Fiyat = 45m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2958)
                        },
                        new
                        {
                            ID = 8,
                            Adi = "Mac&Cheese Balls",
                            AktifMi = true,
                            Cesit = 1,
                            Fiyat = 60m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2960)
                        },
                        new
                        {
                            ID = 9,
                            Adi = "Mozarella Sticks",
                            AktifMi = true,
                            Cesit = 1,
                            Fiyat = 70m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2961)
                        },
                        new
                        {
                            ID = 10,
                            Adi = "Dondurma",
                            AktifMi = true,
                            Cesit = 2,
                            Fiyat = 20m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(2962)
                        });
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.ExtraMalzemelerSiparisler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ExtraMalzemeID")
                        .HasColumnType("int");

                    b.Property<int>("SiparisID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ExtraMalzemeID");

                    b.HasIndex("SiparisID");

                    b.ToTable("ExtraMalzemelerSiparisler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Fotograf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GuncellemeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturmaZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Menuler");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Adi = "Classic",
                            AktifMi = true,
                            Fiyat = 150m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(5526)
                        },
                        new
                        {
                            ID = 2,
                            Adi = "CheeseBurger",
                            AktifMi = true,
                            Fiyat = 170m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(5531)
                        },
                        new
                        {
                            ID = 3,
                            Adi = "Acılı Burger",
                            AktifMi = true,
                            Fiyat = 120m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(5532)
                        },
                        new
                        {
                            ID = 4,
                            Adi = "DoubleBurger",
                            AktifMi = true,
                            Fiyat = 150m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(5533)
                        },
                        new
                        {
                            ID = 5,
                            Adi = "Tavuk Burger",
                            AktifMi = true,
                            Fiyat = 100m,
                            OlusturmaZamani = new DateTime(2024, 5, 17, 15, 39, 49, 497, DateTimeKind.Local).AddTicks(5534)
                        });
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Sepet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("Boyut")
                        .HasColumnType("int");

                    b.Property<int?>("ExtraMalzemeID")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("GuncellemeZamani")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MenuID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OlusturmaZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ExtraMalzemeID");

                    b.HasIndex("MenuID");

                    b.HasIndex("UserID");

                    b.ToTable("Sepettekiler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Siparis", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellemeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturmaZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.SiparislerMenuler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("Boyut")
                        .HasColumnType("int");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("SiparisID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("SiparisID");

                    b.ToTable("SiparislerMenuler");
                });

            modelBuilder.Entity("Mama_Burger.Classes.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "98290741-28e5-40e5-ab47-37aeef9350ba",
                            Name = "Musteri",
                            NormalizedName = "MUSTERI"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "240ae079-b1ec-446c-abe9-b423b71bfad8",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.ExtraMalzemelerSiparisler", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.ExtraMalzeme", "ExtraMalzeme")
                        .WithMany("ExtraMalzemelerSiparisler")
                        .HasForeignKey("ExtraMalzemeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MamaBurger.Classes.Entites.Siparis", "Siparis")
                        .WithMany("ExtraMalzemelerSiparisler")
                        .HasForeignKey("SiparisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraMalzeme");

                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Sepet", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.ExtraMalzeme", "ExtraMalzeme")
                        .WithMany("SepettekiExtraMalzemeler")
                        .HasForeignKey("ExtraMalzemeID");

                    b.HasOne("MamaBurger.Classes.Entites.Menu", "Menu")
                        .WithMany("SepettekiMenuler")
                        .HasForeignKey("MenuID");

                    b.HasOne("MamaBurger.Classes.Entites.AppUser", "User")
                        .WithMany("SepettekiMenuler")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraMalzeme");

                    b.Navigation("Menu");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Siparis", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.AppUser", "AppUser")
                        .WithMany("Siparisler")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.SiparislerMenuler", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.Menu", "Menu")
                        .WithMany("SiparislerMenuler")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MamaBurger.Classes.Entites.Siparis", "Siparis")
                        .WithMany("SiparislerMenuler")
                        .HasForeignKey("SiparisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Mama_Burger.Classes.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Mama_Burger.Classes.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MamaBurger.Classes.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MamaBurger.Classes.Entites.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.AppUser", b =>
                {
                    b.Navigation("SepettekiMenuler");

                    b.Navigation("Siparisler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.ExtraMalzeme", b =>
                {
                    b.Navigation("ExtraMalzemelerSiparisler");

                    b.Navigation("SepettekiExtraMalzemeler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Menu", b =>
                {
                    b.Navigation("SepettekiMenuler");

                    b.Navigation("SiparislerMenuler");
                });

            modelBuilder.Entity("MamaBurger.Classes.Entites.Siparis", b =>
                {
                    b.Navigation("ExtraMalzemelerSiparisler");

                    b.Navigation("SiparislerMenuler");
                });
#pragma warning restore 612, 618
        }
    }
}
