using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class userSkillName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "4b9900df-87f3-45f5-b94e-ce8efd53850f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d", "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42", "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42");

            migrationBuilder.RenameColumn(
                name: "IsSkillsCheck",
                schema: "Identity",
                table: "UserSkills",
                newName: "IsCheck");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "IsCheck",
                schema: "Identity",
                table: "UserSkills",
                newName: "IsSkillsCheck");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b9900df-87f3-45f5-b94e-ce8efd53850f", null, "Admin", "ADMİN" },
                    { "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d", null, "Moderator", "MODERATOR" },
                    { "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d", 0, "8cb8b84b-5c3d-4911-8574-b34433bd9df8", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42", 0, "94611902-6db3-44aa-b4c9-b811c5be572f", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d", "d0dc58b8-0949-4f0a-a9ee-f659a9d80f0d" },
                    { "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42", "fc7ae421-b7f1-48fd-b31e-10aaa1a8bb42" }
                });
        }
    }
}
