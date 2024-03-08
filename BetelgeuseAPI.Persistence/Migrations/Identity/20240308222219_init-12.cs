using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c2727da-48d4-45a9-8751-aa7e23dd77c4", null, "Admin", "ADMİN" },
                    { "da823cb0-a9b9-4711-bf47-407df9e918eb", null, "Student", "STUDENT" },
                    { "f282779c-cf10-4ae6-b5db-e1ace92db4fd", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "da823cb0-a9b9-4711-bf47-407df9e918eb", 0, "2b84aad6-7539-4494-b2af-c55a41ddfd2a", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "f282779c-cf10-4ae6-b5db-e1ace92db4fd", 0, "ab011d01-90ac-46a0-bf83-ca66d80289ef", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "da823cb0-a9b9-4711-bf47-407df9e918eb", "da823cb0-a9b9-4711-bf47-407df9e918eb" },
                    { "f282779c-cf10-4ae6-b5db-e1ace92db4fd", "f282779c-cf10-4ae6-b5db-e1ace92db4fd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "6c2727da-48d4-45a9-8751-aa7e23dd77c4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da823cb0-a9b9-4711-bf47-407df9e918eb", "da823cb0-a9b9-4711-bf47-407df9e918eb" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f282779c-cf10-4ae6-b5db-e1ace92db4fd", "f282779c-cf10-4ae6-b5db-e1ace92db4fd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "da823cb0-a9b9-4711-bf47-407df9e918eb");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f282779c-cf10-4ae6-b5db-e1ace92db4fd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "da823cb0-a9b9-4711-bf47-407df9e918eb");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "f282779c-cf10-4ae6-b5db-e1ace92db4fd");

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
        }
    }
}
