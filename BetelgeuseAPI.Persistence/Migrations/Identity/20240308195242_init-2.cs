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
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_File_BlogImageId",
                schema: "Identity",
                table: "Blogs");

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

            migrationBuilder.DropColumn(
                name: "BlogImageID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogImageId",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogImageID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogImageId",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogImageID");

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
                name: "FK_Blogs_File_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageID",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_File_BlogImageID",
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

            migrationBuilder.RenameColumn(
                name: "BlogImageID",
                schema: "Identity",
                table: "Blogs",
                newName: "BlogImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_BlogImageId");

            migrationBuilder.AddColumn<string>(
                name: "BlogImageID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_File_BlogImageId",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageId",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
