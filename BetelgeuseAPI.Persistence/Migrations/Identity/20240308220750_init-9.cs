using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "bb3b8753-6d97-4425-a1f9-40b217afcb8c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27", "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d0626879-0f88-48d3-af02-76634b728481", "d0626879-0f88-48d3-af02-76634b728481" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d0626879-0f88-48d3-af02-76634b728481");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d0626879-0f88-48d3-af02-76634b728481");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6", null, "Student", "STUDENT" },
                    { "55fa0b27-ab3e-4bc9-a058-1c9f681741e3", null, "Admin", "ADMİN" },
                    { "56082387-86b2-4254-b1f6-ddb5f3cf31d3", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6", 0, "5c0870c7-77e4-411e-bb6c-54d4e4eb4402", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "56082387-86b2-4254-b1f6-ddb5f3cf31d3", 0, "b5a6b1d8-bcf6-4b18-a3b5-bb4bdc68b913", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6", "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6" },
                    { "56082387-86b2-4254-b1f6-ddb5f3cf31d3", "56082387-86b2-4254-b1f6-ddb5f3cf31d3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogCategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogCategoriesID",
                principalSchema: "Identity",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "55fa0b27-ab3e-4bc9-a058-1c9f681741e3");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6", "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56082387-86b2-4254-b1f6-ddb5f3cf31d3", "56082387-86b2-4254-b1f6-ddb5f3cf31d3" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "56082387-86b2-4254-b1f6-ddb5f3cf31d3");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "1ea2455c-2fe9-4d0b-9307-f943f8f5b8f6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "56082387-86b2-4254-b1f6-ddb5f3cf31d3");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27", null, "Moderator", "MODERATOR" },
                    { "bb3b8753-6d97-4425-a1f9-40b217afcb8c", null, "Admin", "ADMİN" },
                    { "d0626879-0f88-48d3-af02-76634b728481", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27", 0, "3a73ea44-d637-4140-903c-ee93e87b5a40", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "d0626879-0f88-48d3-af02-76634b728481", 0, "6843466b-3468-45fa-914f-cf59524a5ce1", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27", "aff0c2d8-72a1-440e-bfb1-4a26d4ab6c27" },
                    { "d0626879-0f88-48d3-af02-76634b728481", "d0626879-0f88-48d3-af02-76634b728481" }
                });
        }
    }
}
