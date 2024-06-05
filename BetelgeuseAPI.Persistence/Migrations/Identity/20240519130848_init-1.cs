using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "1dd24a95-61b6-4ca9-b947-ba250a1d1516");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f38694d-1546-494b-836d-5b49089c5a0d", "4f38694d-1546-494b-836d-5b49089c5a0d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "acc8d0cf-e946-43d1-9896-84344fea9f0b", "acc8d0cf-e946-43d1-9896-84344fea9f0b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "4f38694d-1546-494b-836d-5b49089c5a0d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "acc8d0cf-e946-43d1-9896-84344fea9f0b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "4f38694d-1546-494b-836d-5b49089c5a0d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "acc8d0cf-e946-43d1-9896-84344fea9f0b");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "IsPrimary", "Name", "Published", "SeoCode" },
                values: new object[,]
                {
                    { 1, true, "Türkçe", true, "tr" },
                    { 2, false, "İngilizce", true, "en" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dd24a95-61b6-4ca9-b947-ba250a1d1516", null, "Admin", "ADMİN" },
                    { "4f38694d-1546-494b-836d-5b49089c5a0d", null, "Student", "STUDENT" },
                    { "acc8d0cf-e946-43d1-9896-84344fea9f0b", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4f38694d-1546-494b-836d-5b49089c5a0d", 0, "190916cd-8759-49ac-abea-b467cbcb3cf9", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "acc8d0cf-e946-43d1-9896-84344fea9f0b", 0, "32cbc276-3381-406b-b410-7cc7ee551eff", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4f38694d-1546-494b-836d-5b49089c5a0d", "4f38694d-1546-494b-836d-5b49089c5a0d" },
                    { "acc8d0cf-e946-43d1-9896-84344fea9f0b", "acc8d0cf-e946-43d1-9896-84344fea9f0b" }
                });
        }
    }
}
