using System;
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
                name: "FK_CourseSource_File_CourseUploadId",
                schema: "Identity",
                table: "CourseSource");

            migrationBuilder.DropIndex(
                name: "IX_CourseSource_CourseUploadId",
                schema: "Identity",
                table: "CourseSource");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("6297eb6b-0289-42cc-b725-605996cc152f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("ff685f13-a4a9-4e07-b281-448b5d034da3"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "88433f05-c85b-411a-97de-02afd7f2f872");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a9d2def-7b09-45d5-ac27-4bef600d645e", "5a9d2def-7b09-45d5-ac27-4bef600d645e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8084a5f-efe0-4a42-baf4-12a8f63c10bd", "c8084a5f-efe0-4a42-baf4-12a8f63c10bd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5a9d2def-7b09-45d5-ac27-4bef600d645e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "c8084a5f-efe0-4a42-baf4-12a8f63c10bd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "5a9d2def-7b09-45d5-ac27-4bef600d645e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "c8084a5f-efe0-4a42-baf4-12a8f63c10bd");

            migrationBuilder.DropColumn(
                name: "CourseUploadId",
                schema: "Identity",
                table: "CourseSource");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseSourceId",
                schema: "Identity",
                table: "File",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "CreatedDate", "IsPrimary", "Name", "Published", "SeoCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("122a243f-af0e-49ab-935c-4d1a38c29883"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Türkçe", true, "tr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5b3e98f-be47-4a07-8c83-0f50d0d67aed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce", true, "en", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a38de68-7712-4500-b155-ec8c0f176336", null, "Admin", "ADMİN" },
                    { "2e026eb0-3dfa-4559-a5da-15e6f73bced2", null, "Moderator", "MODERATOR" },
                    { "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e026eb0-3dfa-4559-a5da-15e6f73bced2", 0, "7a16ba27-d8d9-488e-9311-c24cf7f53d3e", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9", 0, "fe2c7226-aa00-4b44-9a7b-99bbe726a2af", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2e026eb0-3dfa-4559-a5da-15e6f73bced2", "2e026eb0-3dfa-4559-a5da-15e6f73bced2" },
                    { "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9", "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_CourseSourceId",
                schema: "Identity",
                table: "File",
                column: "CourseSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_CourseSource_CourseSourceId",
                schema: "Identity",
                table: "File",
                column: "CourseSourceId",
                principalSchema: "Identity",
                principalTable: "CourseSource",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_CourseSource_CourseSourceId",
                schema: "Identity",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_CourseSourceId",
                schema: "Identity",
                table: "File");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("122a243f-af0e-49ab-935c-4d1a38c29883"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("a5b3e98f-be47-4a07-8c83-0f50d0d67aed"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0a38de68-7712-4500-b155-ec8c0f176336");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e026eb0-3dfa-4559-a5da-15e6f73bced2", "2e026eb0-3dfa-4559-a5da-15e6f73bced2" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9", "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2e026eb0-3dfa-4559-a5da-15e6f73bced2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "2e026eb0-3dfa-4559-a5da-15e6f73bced2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "f5a7a18e-23d1-4f0e-8b60-a424b5c84aa9");

            migrationBuilder.DropColumn(
                name: "CourseSourceId",
                schema: "Identity",
                table: "File");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseUploadId",
                schema: "Identity",
                table: "CourseSource",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "CreatedDate", "IsPrimary", "Name", "Published", "SeoCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6297eb6b-0289-42cc-b725-605996cc152f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce", true, "en", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff685f13-a4a9-4e07-b281-448b5d034da3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Türkçe", true, "tr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a9d2def-7b09-45d5-ac27-4bef600d645e", null, "Student", "STUDENT" },
                    { "88433f05-c85b-411a-97de-02afd7f2f872", null, "Admin", "ADMİN" },
                    { "c8084a5f-efe0-4a42-baf4-12a8f63c10bd", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5a9d2def-7b09-45d5-ac27-4bef600d645e", 0, "089792b2-b056-4528-8a0c-f1ec56aebd15", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "c8084a5f-efe0-4a42-baf4-12a8f63c10bd", 0, "50fa3fef-147b-49b4-ad3f-a4c259c4314e", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5a9d2def-7b09-45d5-ac27-4bef600d645e", "5a9d2def-7b09-45d5-ac27-4bef600d645e" },
                    { "c8084a5f-efe0-4a42-baf4-12a8f63c10bd", "c8084a5f-efe0-4a42-baf4-12a8f63c10bd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSource_CourseUploadId",
                schema: "Identity",
                table: "CourseSource",
                column: "CourseUploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSource_File_CourseUploadId",
                schema: "Identity",
                table: "CourseSource",
                column: "CourseUploadId",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id");
        }
    }
}
