using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddblogCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0af3c39b-d8cb-4d2d-b04d-3b0530251278");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "85f4fccd-11ac-42ce-abfa-fc107d54598e", "85f4fccd-11ac-42ce-abfa-fc107d54598e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3642d22-2695-4683-9f59-b22558847f31", "d3642d22-2695-4683-9f59-b22558847f31" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "85f4fccd-11ac-42ce-abfa-fc107d54598e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d3642d22-2695-4683-9f59-b22558847f31");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "85f4fccd-11ac-42ce-abfa-fc107d54598e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d3642d22-2695-4683-9f59-b22558847f31");

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SubTitle = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    { "04c65aff-823c-4079-abe8-f193021c0dee", null, "Admin", "ADMİN" },
                    { "3411fa2e-0b84-4e3d-9de9-314b7256e988", null, "Student", "STUDENT" },
                    { "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3411fa2e-0b84-4e3d-9de9-314b7256e988", 0, "8e6500d9-efd3-434a-8c0a-80a2963bbfbd", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43", 0, "028b0ba7-7180-4455-ba9c-6ac32faa9207", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3411fa2e-0b84-4e3d-9de9-314b7256e988", "3411fa2e-0b84-4e3d-9de9-314b7256e988" },
                    { "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43", "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategories",
                schema: "Identity");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "04c65aff-823c-4079-abe8-f193021c0dee");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3411fa2e-0b84-4e3d-9de9-314b7256e988", "3411fa2e-0b84-4e3d-9de9-314b7256e988" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43", "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3411fa2e-0b84-4e3d-9de9-314b7256e988");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "3411fa2e-0b84-4e3d-9de9-314b7256e988");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "5ab3647a-4d4b-4ee5-bcc9-3a362514ca43");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0af3c39b-d8cb-4d2d-b04d-3b0530251278", null, "Admin", "ADMİN" },
                    { "85f4fccd-11ac-42ce-abfa-fc107d54598e", null, "Student", "STUDENT" },
                    { "d3642d22-2695-4683-9f59-b22558847f31", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "85f4fccd-11ac-42ce-abfa-fc107d54598e", 0, "11af0acf-4ca3-4815-965f-c281f04e1a24", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "d3642d22-2695-4683-9f59-b22558847f31", 0, "2384dc2d-cc92-4b95-a525-21a4c510e9e1", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "85f4fccd-11ac-42ce-abfa-fc107d54598e", "85f4fccd-11ac-42ce-abfa-fc107d54598e" },
                    { "d3642d22-2695-4683-9f59-b22558847f31", "d3642d22-2695-4683-9f59-b22558847f31" }
                });
        }
    }
}
