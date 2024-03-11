using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5be7c483-8492-4240-a2e6-c15d12980321");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", "299c1fc6-84b0-49d1-8f54-55812bc7fcb6" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d20f93a7-a749-48b5-86bc-33d320d5b64e", "d20f93a7-a749-48b5-86bc-33d320d5b64e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "299c1fc6-84b0-49d1-8f54-55812bc7fcb6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d20f93a7-a749-48b5-86bc-33d320d5b64e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "299c1fc6-84b0-49d1-8f54-55812bc7fcb6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d20f93a7-a749-48b5-86bc-33d320d5b64e");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2904378a-ecf5-41fe-9b30-fa313c333d7c", null, "Student", "STUDENT" },
                    { "5b8377b2-8fe2-4000-9e14-31289b25aea0", null, "Moderator", "MODERATOR" },
                    { "b8ef3dd9-36c9-4857-9b9c-095b32f6f770", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2904378a-ecf5-41fe-9b30-fa313c333d7c", 0, "4a21b433-4460-4780-b229-a6e2c8af7cb1", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "5b8377b2-8fe2-4000-9e14-31289b25aea0", 0, "44d6dcb9-1ca3-4cb9-ad9a-706248dc7fbf", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2904378a-ecf5-41fe-9b30-fa313c333d7c", "2904378a-ecf5-41fe-9b30-fa313c333d7c" },
                    { "5b8377b2-8fe2-4000-9e14-31289b25aea0", "5b8377b2-8fe2-4000-9e14-31289b25aea0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "b8ef3dd9-36c9-4857-9b9c-095b32f6f770");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2904378a-ecf5-41fe-9b30-fa313c333d7c", "2904378a-ecf5-41fe-9b30-fa313c333d7c" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b8377b2-8fe2-4000-9e14-31289b25aea0", "5b8377b2-8fe2-4000-9e14-31289b25aea0" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2904378a-ecf5-41fe-9b30-fa313c333d7c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5b8377b2-8fe2-4000-9e14-31289b25aea0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "2904378a-ecf5-41fe-9b30-fa313c333d7c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "5b8377b2-8fe2-4000-9e14-31289b25aea0");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "Category");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", null, "Student", "STUDENT" },
                    { "5be7c483-8492-4240-a2e6-c15d12980321", null, "Admin", "ADMİN" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", 0, "d109b877-5de4-4fdf-8eb7-291e93226065", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", 0, "35f9a404-c23d-4083-9dc4-c4fdd185f5ae", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", "299c1fc6-84b0-49d1-8f54-55812bc7fcb6" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", "d20f93a7-a749-48b5-86bc-33d320d5b64e" }
                });
        }
    }
}
