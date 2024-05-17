using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mama_Burger.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2bf77b5a-88bb-49ae-8573-2162622bc48e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3559c3f4-966c-4e17-bdae-60cdb616cb37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "820374a8-f716-4b22-bc17-0ee2847d7009", "AQAAAAIAAYagAAAAEIgj5ndM6+RYzECfDk9PRaCDstTXEQnTEMs5al/24xgM97lCG/iPcCmmzZRHptHd5g==", "8d58b6d6-313e-402a-a7bf-f850ac73d0f1" });

            migrationBuilder.InsertData(
                table: "ExtraMalzemeler",
                columns: new[] { "ID", "Adi", "AktifMi", "Cesit", "Fiyat", "GuncellemeZamani", "OlusturmaZamani", "SilinmeZamani" },
                values: new object[,]
                {
                    { 1, "Ketçap", true, 0, 5m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3741), null },
                    { 2, "Mayonez", true, 0, 5m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3757), null },
                    { 3, "Ranch Sos", true, 0, 5m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3759), null },
                    { 4, "Barbekü Sos", true, 0, 5m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3761), null },
                    { 6, "Sufle", true, 2, 5m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3762), null },
                    { 7, "Patates Kızartması", true, 1, 45m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3764), null },
                    { 8, "Mac&Cheese Balls", true, 1, 60m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3765), null },
                    { 9, "Mozarella Sticks", true, 1, 70m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3767), null },
                    { 10, "Dondurma", true, 2, 20m, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(3769), null }
                });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "ID", "Adi", "AktifMi", "Fiyat", "Fotograf", "GuncellemeZamani", "OlusturmaZamani", "SilinmeZamani" },
                values: new object[,]
                {
                    { 1, "Classic", true, 150m, null, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(7877), null },
                    { 2, "CheeseBurger", true, 170m, null, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(7883), null },
                    { 3, "Acılı Burger", true, 120m, null, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(7885), null },
                    { 4, "DoubleBurger", true, 150m, null, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(7887), null },
                    { 5, "Tavuk Burger", true, 100m, null, null, new DateTime(2024, 5, 17, 12, 9, 49, 114, DateTimeKind.Local).AddTicks(7888), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExtraMalzemeler",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d6ba2c29-6c36-4c61-ad25-744762e6928b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4dabe537-39bc-4b7b-9861-340b4c5ef289");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80efaab2-131d-4386-a12c-f7ec5f24b47f", "AQAAAAIAAYagAAAAEJ/o9NGtdxhpUOODUptE5hL0kw91a99vbUGmTH8noIyZSyGrNWCCmUcyM5jLM1uDEA==", "45781bb5-25e7-4a84-8236-51e4bd61ea2a" });
        }
    }
}
