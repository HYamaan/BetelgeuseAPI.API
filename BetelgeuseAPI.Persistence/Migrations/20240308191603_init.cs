using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetelgeuseAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseParentSubTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentTopic = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseParentSubTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseChildSubTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubTitle = table.Column<string>(type: "text", nullable: false),
                    CourseParentSubTopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseChildSubTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseChildSubTopics_CourseParentSubTopics_CourseParentSubT~",
                        column: x => x.CourseParentSubTopicId,
                        principalTable: "CourseParentSubTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseVideoSubTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Publish = table.Column<bool>(type: "boolean", nullable: false),
                    CourseSubTopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVideoSubTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseVideoSubTopics_CourseChildSubTopics_CourseSubTopicId",
                        column: x => x.CourseSubTopicId,
                        principalTable: "CourseChildSubTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseChildSubTopics_CourseParentSubTopicId",
                table: "CourseChildSubTopics",
                column: "CourseParentSubTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVideoSubTopics_CourseSubTopicId",
                table: "CourseVideoSubTopics",
                column: "CourseSubTopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseVideoSubTopics");

            migrationBuilder.DropTable(
                name: "CourseChildSubTopics");

            migrationBuilder.DropTable(
                name: "CourseParentSubTopics");
        }
    }
}
