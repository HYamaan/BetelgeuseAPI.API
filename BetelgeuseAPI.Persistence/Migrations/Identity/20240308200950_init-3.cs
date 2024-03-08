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
                name: "FK_Blogs_BlogCategories_BlogCategoriesId",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "e64e5fae-8747-4303-89c6-ed4c7e474a8b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0cb0fd78-dbcb-4b85-8a4c-edd214595781", "0cb0fd78-dbcb-4b85-8a4c-edd214595781" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d14349db-f8d5-4390-bb77-ec61d4834f9c", "d14349db-f8d5-4390-bb77-ec61d4834f9c" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0cb0fd78-dbcb-4b85-8a4c-edd214595781");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d14349db-f8d5-4390-bb77-ec61d4834f9c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "0cb0fd78-dbcb-4b85-8a4c-edd214595781");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d14349db-f8d5-4390-bb77-ec61d4834f9c");

            migrationBuilder.DropColumn(
                name: "BlogCategoriesID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogCategoriesId",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogCategoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogCategoriesId",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogCategoriesID");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3250ed92-1f5a-43f0-ac37-78bbb8cc9c0d", null, "Admin", "ADMİN" },
                    { "ebbcb664-750b-42da-b0e7-3251ff103226", null, "Student", "STUDENT" },
                    { "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ebbcb664-750b-42da-b0e7-3251ff103226", 0, "8f659075-0891-4ed7-8f01-44f5cf7598a6", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744", 0, "d66cdd00-ee88-4319-8f3f-e63d0dac377c", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ebbcb664-750b-42da-b0e7-3251ff103226", "ebbcb664-750b-42da-b0e7-3251ff103226" },
                    { "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744", "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3250ed92-1f5a-43f0-ac37-78bbb8cc9c0d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebbcb664-750b-42da-b0e7-3251ff103226", "ebbcb664-750b-42da-b0e7-3251ff103226" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744", "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "ebbcb664-750b-42da-b0e7-3251ff103226");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "ebbcb664-750b-42da-b0e7-3251ff103226");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "fc8e0b75-1fe9-4296-bd2d-9d14b6ef0744");

            migrationBuilder.RenameColumn(
                name: "BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogCategoriesId");

            migrationBuilder.AddColumn<string>(
                name: "BlogCategoriesID",
                schema: "Identity",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cb0fd78-dbcb-4b85-8a4c-edd214595781", null, "Moderator", "MODERATOR" },
                    { "d14349db-f8d5-4390-bb77-ec61d4834f9c", null, "Student", "STUDENT" },
                    { "e64e5fae-8747-4303-89c6-ed4c7e474a8b", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0cb0fd78-dbcb-4b85-8a4c-edd214595781", 0, "0729560d-3a55-4c4b-afda-04d91eebb453", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "d14349db-f8d5-4390-bb77-ec61d4834f9c", 0, "96545a4e-d918-4048-af13-8076652d3fae", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0cb0fd78-dbcb-4b85-8a4c-edd214595781", "0cb0fd78-dbcb-4b85-8a4c-edd214595781" },
                    { "d14349db-f8d5-4390-bb77-ec61d4834f9c", "d14349db-f8d5-4390-bb77-ec61d4834f9c" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoriesId",
                schema: "Identity",
                table: "Blogs",
                column: "BlogCategoriesId",
                principalSchema: "Identity",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
