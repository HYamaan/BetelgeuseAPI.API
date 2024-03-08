using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_File_BlogImageID",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogImageID",
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

            migrationBuilder.AddColumn<Guid>(
                name: "BlogsId",
                schema: "Identity",
                table: "File",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_File_BlogsId",
                schema: "Identity",
                table: "File",
                column: "BlogsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_File_Blogs_BlogsId",
                schema: "Identity",
                table: "File",
                column: "BlogsId",
                principalSchema: "Identity",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Blogs_BlogsId",
                schema: "Identity",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_BlogsId",
                schema: "Identity",
                table: "File");

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

            migrationBuilder.DropColumn(
                name: "BlogsId",
                schema: "Identity",
                table: "File");

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

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageID");

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
    }
}
