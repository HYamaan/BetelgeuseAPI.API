using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "19ce98a7-df78-47e8-81ab-6dc53fa6fd82", null, "Admin", "ADMİN" },
                    { "8e57d9a9-cbff-4368-be83-25b452c58ef4", null, "Student", "STUDENT" },
                    { "c7d2b7b3-1592-41c6-ad40-8f2275267d30", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e57d9a9-cbff-4368-be83-25b452c58ef4", 0, "fcc949c9-1782-4eec-86dc-a86fbeb6446c", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "c7d2b7b3-1592-41c6-ad40-8f2275267d30", 0, "f19767b8-3807-4808-9a36-c6bb8aef7b1b", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8e57d9a9-cbff-4368-be83-25b452c58ef4", "8e57d9a9-cbff-4368-be83-25b452c58ef4" },
                    { "c7d2b7b3-1592-41c6-ad40-8f2275267d30", "c7d2b7b3-1592-41c6-ad40-8f2275267d30" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "19ce98a7-df78-47e8-81ab-6dc53fa6fd82");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e57d9a9-cbff-4368-be83-25b452c58ef4", "8e57d9a9-cbff-4368-be83-25b452c58ef4" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7d2b7b3-1592-41c6-ad40-8f2275267d30", "c7d2b7b3-1592-41c6-ad40-8f2275267d30" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e57d9a9-cbff-4368-be83-25b452c58ef4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "c7d2b7b3-1592-41c6-ad40-8f2275267d30");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "8e57d9a9-cbff-4368-be83-25b452c58ef4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "c7d2b7b3-1592-41c6-ad40-8f2275267d30");

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
    }
}
