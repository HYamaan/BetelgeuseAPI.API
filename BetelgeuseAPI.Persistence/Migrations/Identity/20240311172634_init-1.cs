using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "a3a8640f-f1bf-4bd0-a5cc-fb7c4845d0f2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "52c08d9d-5ff0-4d09-a26d-2b3b246ec234", "52c08d9d-5ff0-4d09-a26d-2b3b246ec234" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01", "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "52c08d9d-5ff0-4d09-a26d-2b3b246ec234");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "52c08d9d-5ff0-4d09-a26d-2b3b246ec234");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    ParentCategoryID = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalSchema: "Identity",
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", null, "Student", "STUDENT" },
                    { "5be7c483-8492-4240-a2e6-c15d12980321", null, "Admin", "ADMİN" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", 0, "d109b877-5de4-4fdf-8eb7-291e93226065", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", 0, "35f9a404-c23d-4083-9dc4-c4fdd185f5ae", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", "299c1fc6-84b0-49d1-8f54-55812bc7fcb6" },
                    { "d20f93a7-a749-48b5-86bc-33d320d5b64e", "d20f93a7-a749-48b5-86bc-33d320d5b64e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                schema: "Identity",
                table: "Category",
                column: "ParentCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "Identity");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5be7c483-8492-4240-a2e6-c15d12980321");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "299c1fc6-84b0-49d1-8f54-55812bc7fcb6", "299c1fc6-84b0-49d1-8f54-55812bc7fcb6" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d20f93a7-a749-48b5-86bc-33d320d5b64e", "d20f93a7-a749-48b5-86bc-33d320d5b64e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "299c1fc6-84b0-49d1-8f54-55812bc7fcb6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d20f93a7-a749-48b5-86bc-33d320d5b64e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "299c1fc6-84b0-49d1-8f54-55812bc7fcb6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d20f93a7-a749-48b5-86bc-33d320d5b64e");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52c08d9d-5ff0-4d09-a26d-2b3b246ec234", null, "Student", "STUDENT" },
                    { "a3a8640f-f1bf-4bd0-a5cc-fb7c4845d0f2", null, "Admin", "ADMİN" },
                    { "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "52c08d9d-5ff0-4d09-a26d-2b3b246ec234", 0, "56c5c7f3-2279-4319-a0bd-1a52247db59a", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01", 0, "de468863-877c-4777-ad5f-2ede9496eb4d", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "52c08d9d-5ff0-4d09-a26d-2b3b246ec234", "52c08d9d-5ff0-4d09-a26d-2b3b246ec234" },
                    { "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01", "a5b7eb47-0dca-4c69-81c3-bf5c365b6a01" }
                });
        }
    }
}
