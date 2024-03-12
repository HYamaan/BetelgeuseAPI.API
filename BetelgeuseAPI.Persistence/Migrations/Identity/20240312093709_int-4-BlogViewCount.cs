using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class int4BlogViewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "660262dc-8fe6-46bc-b6ac-db3ba88bbe3f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0fac6596-d746-4961-a084-40e54f800d88", "0fac6596-d746-4961-a084-40e54f800d88" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b", "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0fac6596-d746-4961-a084-40e54f800d88");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "0fac6596-d746-4961-a084-40e54f800d88");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                schema: "Identity",
                table: "Blogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b3c5de8-1944-4b4f-b362-777d9486d7ba", null, "Student", "STUDENT" },
                    { "3fb5f07d-9705-4854-b31d-feb4a2064ea4", null, "Moderator", "MODERATOR" },
                    { "f34be3cd-aeb8-4fc1-8518-9cf480820ef6", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b3c5de8-1944-4b4f-b362-777d9486d7ba", 0, "c519587a-a5c7-4a95-9219-c62cbdcfed53", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "3fb5f07d-9705-4854-b31d-feb4a2064ea4", 0, "4487286b-fb47-4381-b99e-d6d1b7c20354", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0b3c5de8-1944-4b4f-b362-777d9486d7ba", "0b3c5de8-1944-4b4f-b362-777d9486d7ba" },
                    { "3fb5f07d-9705-4854-b31d-feb4a2064ea4", "3fb5f07d-9705-4854-b31d-feb4a2064ea4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f34be3cd-aeb8-4fc1-8518-9cf480820ef6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b3c5de8-1944-4b4f-b362-777d9486d7ba", "0b3c5de8-1944-4b4f-b362-777d9486d7ba" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3fb5f07d-9705-4854-b31d-feb4a2064ea4", "3fb5f07d-9705-4854-b31d-feb4a2064ea4" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0b3c5de8-1944-4b4f-b362-777d9486d7ba");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3fb5f07d-9705-4854-b31d-feb4a2064ea4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "0b3c5de8-1944-4b4f-b362-777d9486d7ba");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "3fb5f07d-9705-4854-b31d-feb4a2064ea4");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fac6596-d746-4961-a084-40e54f800d88", null, "Student", "STUDENT" },
                    { "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b", null, "Moderator", "MODERATOR" },
                    { "660262dc-8fe6-46bc-b6ac-db3ba88bbe3f", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0fac6596-d746-4961-a084-40e54f800d88", 0, "ac4c8da8-2a55-433d-9fbd-559569a25e0f", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b", 0, "721345ec-0d5c-4811-b383-2192b8aaffdb", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0fac6596-d746-4961-a084-40e54f800d88", "0fac6596-d746-4961-a084-40e54f800d88" },
                    { "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b", "3696cf85-2a15-4ae5-8d2b-54f7a38bae7b" }
                });
        }
    }
}
