using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogCategories",
                schema: "Identity");

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

            migrationBuilder.RenameColumn(
                name: "BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Category_BlogCategoryId",
                schema: "Identity",
                table: "Blogs",
                column: "BlogCategoryId",
                principalSchema: "Identity",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Category_BlogCategoryId",
                schema: "Identity",
                table: "Blogs");

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

            migrationBuilder.RenameColumn(
                name: "BlogCategoryId",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogCategoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogCategoryId",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogCategoriesID");

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    SubTitle = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

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
    }
}
