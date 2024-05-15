using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mama_Burger.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mahmut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfirmCode",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExtraMalzemeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cesit = table.Column<int>(type: "int", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemeler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fotograf = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepettekiler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    ExtraMalzemeID = table.Column<int>(type: "int", nullable: true),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Boyut = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepettekiler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sepettekiler_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepettekiler_ExtraMalzemeler_ExtraMalzemeID",
                        column: x => x.ExtraMalzemeID,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sepettekiler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExtraMalzemelerSiparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraMalzemeID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemelerSiparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemelerSiparisler_ExtraMalzemeler_ExtraMalzemeID",
                        column: x => x.ExtraMalzemeID,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemelerSiparisler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparislerMenuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Boyut = table.Column<int>(type: "int", nullable: false),
                    TotalFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparislerMenuler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SiparislerMenuler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparislerMenuler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemelerSiparisler_ExtraMalzemeID",
                table: "ExtraMalzemelerSiparisler",
                column: "ExtraMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemelerSiparisler_SiparisID",
                table: "ExtraMalzemelerSiparisler",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_ExtraMalzemeID",
                table: "Sepettekiler",
                column: "ExtraMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_MenuID",
                table: "Sepettekiler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_UserId",
                table: "Sepettekiler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UserID",
                table: "Siparisler",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparislerMenuler_MenuID",
                table: "SiparislerMenuler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparislerMenuler_SiparisID",
                table: "SiparislerMenuler",
                column: "SiparisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMalzemelerSiparisler");

            migrationBuilder.DropTable(
                name: "Sepettekiler");

            migrationBuilder.DropTable(
                name: "SiparislerMenuler");

            migrationBuilder.DropTable(
                name: "ExtraMalzemeler");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "AspNetUsers");
        }
    }
}
