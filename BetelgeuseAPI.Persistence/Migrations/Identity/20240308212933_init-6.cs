using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "cbd35404-8c9a-4258-b636-6a4373a33078");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ed18108-2bbd-4a35-abb8-7df5aaaa8034", "3ed18108-2bbd-4a35-abb8-7df5aaaa8034" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba", "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3ed18108-2bbd-4a35-abb8-7df5aaaa8034");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "3ed18108-2bbd-4a35-abb8-7df5aaaa8034");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", null, "Moderator", "MODERATOR" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", null, "Student", "STUDENT" },
                    { "d90d015b-81ed-4c08-8b12-b2e99737ed0e", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", 0, "92e31ccd-937c-48f2-9e94-f8643f4a698c", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", 0, "37c48d86-750f-41fc-9284-1dce451fedd2", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", "2d93e4fb-3236-47ee-8720-ad970fbef35d" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d90d015b-81ed-4c08-8b12-b2e99737ed0e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d93e4fb-3236-47ee-8720-ad970fbef35d", "2d93e4fb-3236-47ee-8720-ad970fbef35d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2d93e4fb-3236-47ee-8720-ad970fbef35d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "2d93e4fb-3236-47ee-8720-ad970fbef35d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ed18108-2bbd-4a35-abb8-7df5aaaa8034", null, "Student", "STUDENT" },
                    { "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba", null, "Moderator", "MODERATOR" },
                    { "cbd35404-8c9a-4258-b636-6a4373a33078", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ed18108-2bbd-4a35-abb8-7df5aaaa8034", 0, "2664390f-4d82-4723-9446-03d89342fa27", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba", 0, "28e01085-5a0c-469e-b649-efbe9f8937bd", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3ed18108-2bbd-4a35-abb8-7df5aaaa8034", "3ed18108-2bbd-4a35-abb8-7df5aaaa8034" },
                    { "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba", "9efa9dfb-c3f1-484b-9a3a-b0cb43ee83ba" }
                });
        }
    }
}
