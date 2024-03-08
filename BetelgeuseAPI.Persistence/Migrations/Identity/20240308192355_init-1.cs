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
                table: "Role",
                keyColumn: "Id",
                keyValue: "7857823c-94fe-4ef4-ae46-d0c5b46b7f49");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1967f7af-73ad-4769-9c23-4d54ff4c45cc", "1967f7af-73ad-4769-9c23-4d54ff4c45cc" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ce0fb8-31f0-4316-b836-f2cefca889ea", "88ce0fb8-31f0-4316-b836-f2cefca889ea" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "1967f7af-73ad-4769-9c23-4d54ff4c45cc");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "88ce0fb8-31f0-4316-b836-f2cefca889ea");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "1967f7af-73ad-4769-9c23-4d54ff4c45cc");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "88ce0fb8-31f0-4316-b836-f2cefca889ea");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3e59358-9760-497a-9331-4557c9247b99", null, "Student", "STUDENT" },
                    { "bfaa3e4b-b89f-45ad-95b7-2fb72cd9865c", null, "Admin", "ADMİN" },
                    { "fa666c61-a84d-41cd-9dc2-7450e40b0f89", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a3e59358-9760-497a-9331-4557c9247b99", 0, "bf238d4e-eb3c-4875-8329-675c03352a01", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "fa666c61-a84d-41cd-9dc2-7450e40b0f89", 0, "3fc5332b-093e-4932-9f8b-f2623e137943", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a3e59358-9760-497a-9331-4557c9247b99", "a3e59358-9760-497a-9331-4557c9247b99" },
                    { "fa666c61-a84d-41cd-9dc2-7450e40b0f89", "fa666c61-a84d-41cd-9dc2-7450e40b0f89" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "bfaa3e4b-b89f-45ad-95b7-2fb72cd9865c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3e59358-9760-497a-9331-4557c9247b99", "a3e59358-9760-497a-9331-4557c9247b99" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa666c61-a84d-41cd-9dc2-7450e40b0f89", "fa666c61-a84d-41cd-9dc2-7450e40b0f89" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "a3e59358-9760-497a-9331-4557c9247b99");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "fa666c61-a84d-41cd-9dc2-7450e40b0f89");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "a3e59358-9760-497a-9331-4557c9247b99");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "fa666c61-a84d-41cd-9dc2-7450e40b0f89");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1967f7af-73ad-4769-9c23-4d54ff4c45cc", null, "Student", "STUDENT" },
                    { "7857823c-94fe-4ef4-ae46-d0c5b46b7f49", null, "Admin", "ADMİN" },
                    { "88ce0fb8-31f0-4316-b836-f2cefca889ea", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1967f7af-73ad-4769-9c23-4d54ff4c45cc", 0, "dde0927c-2973-4fa8-9a96-8fd0298c3466", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "88ce0fb8-31f0-4316-b836-f2cefca889ea", 0, "b21aa4cf-7c62-4dd3-8b77-bbc1679438a7", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1967f7af-73ad-4769-9c23-4d54ff4c45cc", "1967f7af-73ad-4769-9c23-4d54ff4c45cc" },
                    { "88ce0fb8-31f0-4316-b836-f2cefca889ea", "88ce0fb8-31f0-4316-b836-f2cefca889ea" }
                });
        }
    }
}
