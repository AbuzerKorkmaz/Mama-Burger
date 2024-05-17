using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mama_Burger.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "Cinsiyet", "ConcurrencyStamp", "ConfirmCode", "DogumTarihi", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Cevdet", 0, "80efaab2-131d-4386-a12c-f7ec5f24b47f", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cevdet@deneme.com", false, false, null, "CEVDET@DENEME.COM", "CEVDET@DENEME.COM", "AQAAAAIAAYagAAAAEJ/o9NGtdxhpUOODUptE5hL0kw91a99vbUGmTH8noIyZSyGrNWCCmUcyM5jLM1uDEA==", null, false, "45781bb5-25e7-4a84-8236-51e4bd61ea2a", "Heredot", false, "cevdet@deneme.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2336d0b0-dca8-48a1-b669-026fdac163d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "69aadf2c-45b9-4dc0-84e2-3929d8659ac2");
        }
    }
}
