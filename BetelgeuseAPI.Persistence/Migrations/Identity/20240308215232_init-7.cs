using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init7 : Migration
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
                keyValue: "d90d015b-81ed-4c08-8b12-b2e99737ed0e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d93e4fb-3236-47ee-8720-ad970fbef35d", "2d93e4fb-3236-47ee-8720-ad970fbef35d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2d93e4fb-3236-47ee-8720-ad970fbef35d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "2d93e4fb-3236-47ee-8720-ad970fbef35d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5");

            migrationBuilder.RenameColumn(
                name: "BlogsId",
                schema: "Identity",
                table: "File",
                newName: "BlogImageID");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25178cbb-f158-4375-8915-4258276c7a61", null, "Admin", "ADMİN" },
                    { "a90801b7-212f-41ad-b60a-df306eb00e0a", null, "Moderator", "MODERATOR" },
                    { "ce8a6fc1-5796-4fc2-9c49-597b501fe95b", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a90801b7-212f-41ad-b60a-df306eb00e0a", 0, "837956f1-09cd-4c20-b785-2c232c778906", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "ce8a6fc1-5796-4fc2-9c49-597b501fe95b", 0, "de405065-c724-4d18-94cd-4157b7b95894", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a90801b7-212f-41ad-b60a-df306eb00e0a", "a90801b7-212f-41ad-b60a-df306eb00e0a" },
                    { "ce8a6fc1-5796-4fc2-9c49-597b501fe95b", "ce8a6fc1-5796-4fc2-9c49-597b501fe95b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageID",
                unique: true);

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
                keyValue: "25178cbb-f158-4375-8915-4258276c7a61");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a90801b7-212f-41ad-b60a-df306eb00e0a", "a90801b7-212f-41ad-b60a-df306eb00e0a" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce8a6fc1-5796-4fc2-9c49-597b501fe95b", "ce8a6fc1-5796-4fc2-9c49-597b501fe95b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "a90801b7-212f-41ad-b60a-df306eb00e0a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "ce8a6fc1-5796-4fc2-9c49-597b501fe95b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "a90801b7-212f-41ad-b60a-df306eb00e0a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "ce8a6fc1-5796-4fc2-9c49-597b501fe95b");

            migrationBuilder.RenameColumn(
                name: "BlogImageID",
                schema: "Identity",
                table: "File",
                newName: "BlogsId");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", null, "Moderator", "MODERATOR" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", null, "Student", "STUDENT" },
                    { "d90d015b-81ed-4c08-8b12-b2e99737ed0e", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", 0, "92e31ccd-937c-48f2-9e94-f8643f4a698c", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", 0, "37c48d86-750f-41fc-9284-1dce451fedd2", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d93e4fb-3236-47ee-8720-ad970fbef35d", "2d93e4fb-3236-47ee-8720-ad970fbef35d" },
                    { "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5", "d4d5f6f3-f2b8-4ba1-8f8a-03b04d61e8b5" }
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
