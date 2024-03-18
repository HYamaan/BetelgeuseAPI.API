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
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("17041c45-db2a-4073-a452-82ef3d526112"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("a3f2cfb1-3756-4ad4-bcf6-a04d1563d5ff"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2994ef65-c89f-44ef-8599-abc134f9769a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8a98c227-bc65-4252-81c6-9575a8a5f1ad", "8a98c227-bc65-4252-81c6-9575a8a5f1ad" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1ff75ec-ca40-47af-8433-a01e2809d234", "c1ff75ec-ca40-47af-8433-a01e2809d234" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "8a98c227-bc65-4252-81c6-9575a8a5f1ad");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "c1ff75ec-ca40-47af-8433-a01e2809d234");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "8a98c227-bc65-4252-81c6-9575a8a5f1ad");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "c1ff75ec-ca40-47af-8433-a01e2809d234");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "CreatedDate", "IsPrimary", "Name", "Published", "SeoCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("353bd1e3-842b-46a6-9a7d-6d365849430b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce", true, "en", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c6d886c-f6fc-4dcf-976c-88117518d27a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Türkçe", true, "tr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "291ee979-4f92-4e25-abcf-a8e4e880e7cc", null, "Admin", "ADMİN" },
                    { "81c5a217-ba77-487d-a25d-a3a25ba9932d", null, "Student", "STUDENT" },
                    { "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "81c5a217-ba77-487d-a25d-a3a25ba9932d", 0, "0dce8e10-d212-401b-b3ee-0adcbba2ad51", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" },
                    { "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41", 0, "c5152d5b-4914-4cbe-af91-e126a19fc1af", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "81c5a217-ba77-487d-a25d-a3a25ba9932d", "81c5a217-ba77-487d-a25d-a3a25ba9932d" },
                    { "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41", "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("353bd1e3-842b-46a6-9a7d-6d365849430b"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("6c6d886c-f6fc-4dcf-976c-88117518d27a"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "291ee979-4f92-4e25-abcf-a8e4e880e7cc");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81c5a217-ba77-487d-a25d-a3a25ba9932d", "81c5a217-ba77-487d-a25d-a3a25ba9932d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41", "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "81c5a217-ba77-487d-a25d-a3a25ba9932d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "81c5a217-ba77-487d-a25d-a3a25ba9932d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "fb099bbc-ef8c-4fdc-b93a-7c25de8bea41");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "CreatedDate", "IsPrimary", "Name", "Published", "SeoCode", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("17041c45-db2a-4073-a452-82ef3d526112"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce", true, "en", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3f2cfb1-3756-4ad4-bcf6-a04d1563d5ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Türkçe", true, "tr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2994ef65-c89f-44ef-8599-abc134f9769a", null, "Admin", "ADMİN" },
                    { "8a98c227-bc65-4252-81c6-9575a8a5f1ad", null, "Moderator", "MODERATOR" },
                    { "c1ff75ec-ca40-47af-8433-a01e2809d234", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8a98c227-bc65-4252-81c6-9575a8a5f1ad", 0, "d96c5a15-4347-43ce-bbcc-0895eaaebf61", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "c1ff75ec-ca40-47af-8433-a01e2809d234", 0, "c79cdfde-143b-4071-b0ad-43d30517347e", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8a98c227-bc65-4252-81c6-9575a8a5f1ad", "8a98c227-bc65-4252-81c6-9575a8a5f1ad" },
                    { "c1ff75ec-ca40-47af-8433-a01e2809d234", "c1ff75ec-ca40-47af-8433-a01e2809d234" }
                });
        }
    }
}
