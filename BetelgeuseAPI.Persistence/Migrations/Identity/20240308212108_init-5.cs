using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac13459a-8e6c-4286-bea1-94a9feb0c12e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10a6d55a-4441-4651-af3b-5680b2245394", "10a6d55a-4441-4651-af3b-5680b2245394" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "155392ad-0d31-4e9c-a032-1f7630c67324", "155392ad-0d31-4e9c-a032-1f7630c67324" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "10a6d55a-4441-4651-af3b-5680b2245394");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "155392ad-0d31-4e9c-a032-1f7630c67324");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "10a6d55a-4441-4651-af3b-5680b2245394");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "155392ad-0d31-4e9c-a032-1f7630c67324");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "10a6d55a-4441-4651-af3b-5680b2245394", null, "Student", "STUDENT" },
                    { "155392ad-0d31-4e9c-a032-1f7630c67324", null, "Moderator", "MODERATOR" },
                    { "ac13459a-8e6c-4286-bea1-94a9feb0c12e", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10a6d55a-4441-4651-af3b-5680b2245394", 0, "a0a0bcbb-0d07-4169-ad2c-53f6f725c9f8", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "155392ad-0d31-4e9c-a032-1f7630c67324", 0, "0ad9a301-d208-464e-ac37-deda9880824f", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "10a6d55a-4441-4651-af3b-5680b2245394", "10a6d55a-4441-4651-af3b-5680b2245394" },
                    { "155392ad-0d31-4e9c-a032-1f7630c67324", "155392ad-0d31-4e9c-a032-1f7630c67324" }
                });
        }
    }
}
