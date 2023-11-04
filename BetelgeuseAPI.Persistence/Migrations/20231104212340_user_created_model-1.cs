using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetelgeuseAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class user_created_model1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Files");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Files",
                type: "text",
                nullable: true);
        }
    }
}
