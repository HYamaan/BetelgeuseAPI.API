using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class oneToManyUserSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSkills_AppUserId",
                schema: "Identity",
                table: "UserSkills");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "e8d6055d-fe33-4600-ab1c-454f0fb3a42e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e06d8e31-2c7a-44da-8126-77118975857f", "e06d8e31-2c7a-44da-8126-77118975857f" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c", "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "e06d8e31-2c7a-44da-8126-77118975857f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "e06d8e31-2c7a-44da-8126-77118975857f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_AppUserId",
                schema: "Identity",
                table: "UserSkills",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSkills_AppUserId",
                schema: "Identity",
                table: "UserSkills");

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

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e06d8e31-2c7a-44da-8126-77118975857f", null, "Student", "STUDENT" },
                    { "e8d6055d-fe33-4600-ab1c-454f0fb3a42e", null, "Admin", "ADMİN" },
                    { "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e06d8e31-2c7a-44da-8126-77118975857f", 0, "66e782d5-6940-469b-ac7e-ecc9cb69a9ce", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c", 0, "1c3ecfe8-4c90-4980-815d-66c5cb093f70", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e06d8e31-2c7a-44da-8126-77118975857f", "e06d8e31-2c7a-44da-8126-77118975857f" },
                    { "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c", "f280ef8c-8ff9-4ebb-80eb-ce4d0ef3633c" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_AppUserId",
                schema: "Identity",
                table: "UserSkills",
                column: "AppUserId",
                unique: true);
        }
    }
}
