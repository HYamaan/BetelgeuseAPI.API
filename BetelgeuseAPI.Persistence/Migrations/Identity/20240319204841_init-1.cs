using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AllUserSkills",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Skill = table.Column<string>(type: "text", nullable: false),
                    IsCheck = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllUserSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    ParentCategoryID = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CourseContent",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursePricing",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePricing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeoCode = table.Column<string>(type: "text", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaData",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "text", nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaKeywords = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PassAllParts = table.Column<bool>(type: "boolean", nullable: false),
                    CourseContentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSections_CourseContent_CourseContentId",
                        column: x => x.CourseContentId,
                        principalSchema: "Identity",
                        principalTable: "CourseContent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewCoursePricingPlan",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoursePricingId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCoursePricingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewCoursePricingPlan_CoursePricing_CoursePricingId",
                        column: x => x.CoursePricingId,
                        principalSchema: "Identity",
                        principalTable: "CoursePricing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseExtraInformation",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    IsCourseForm = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupport = table.Column<bool>(type: "boolean", nullable: false),
                    IsDownloadable = table.Column<bool>(type: "boolean", nullable: false),
                    IsPartnered = table.Column<bool>(type: "boolean", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    CourseSubLanguage = table.Column<string>(type: "text", nullable: false),
                    CourseLevel = table.Column<int>(type: "integer", nullable: false),
                    PartnerId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExtraInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseExtraInformation_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Identity",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExtraInformation_User_PartnerId",
                        column: x => x.PartnerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccountEducations",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountEducations_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountExperiences",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Experiences = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountExperiences_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountInformation",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    EmailNews = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountInformation_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountInformationAbout",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountInformationAbout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountInformationAbout_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    AllUserSkillsId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCheck = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_AllUserSkills_AllUserSkillsId",
                        column: x => x.AllUserSkillsId,
                        principalSchema: "Identity",
                        principalTable: "AllUserSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogImageID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    MetaDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Category_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalSchema: "Identity",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_File_BlogImageID",
                        column: x => x.BlogImageID,
                        principalSchema: "Identity",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_MetaData_MetaDataId",
                        column: x => x.MetaDataId,
                        principalSchema: "Identity",
                        principalTable: "MetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseBasicInformation",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseType = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SeoDescription = table.Column<string>(type: "text", nullable: false),
                    ThumbnailId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoverImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBasicInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseBasicInformation_File_CoverImageId",
                        column: x => x.CoverImageId,
                        principalSchema: "Identity",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseBasicInformation_File_ThumbnailId",
                        column: x => x.ThumbnailId,
                        principalSchema: "Identity",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSource",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: true),
                    CourseUploadId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseSectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSource_CourseSections_CourseSectionsId",
                        column: x => x.CourseSectionsId,
                        principalSchema: "Identity",
                        principalTable: "CourseSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSource_File_CourseUploadId",
                        column: x => x.CourseUploadId,
                        principalSchema: "Identity",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InclusiveCourse",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseBasicInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseExtraInformationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoursePricingId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseContentId = table.Column<Guid>(type: "uuid", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InclusiveCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InclusiveCourse_CourseBasicInformation_CourseBasicInformati~",
                        column: x => x.CourseBasicInformationId,
                        principalSchema: "Identity",
                        principalTable: "CourseBasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InclusiveCourse_CourseContent_CourseContentId",
                        column: x => x.CourseContentId,
                        principalSchema: "Identity",
                        principalTable: "CourseContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InclusiveCourse_CourseExtraInformation_CourseExtraInformati~",
                        column: x => x.CourseExtraInformationId,
                        principalSchema: "Identity",
                        principalTable: "CourseExtraInformation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InclusiveCourse_CoursePricing_CoursePricingId",
                        column: x => x.CoursePricingId,
                        principalSchema: "Identity",
                        principalTable: "CoursePricing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InclusiveCourse_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

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
                name: "IX_Blogs_BlogCategoryId",
                schema: "Identity",
                table: "Blogs",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_MetaDataId",
                schema: "Identity",
                table: "Blogs",
                column: "MetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                schema: "Identity",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBasicInformation_CoverImageId",
                schema: "Identity",
                table: "CourseBasicInformation",
                column: "CoverImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBasicInformation_ThumbnailId",
                schema: "Identity",
                table: "CourseBasicInformation",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExtraInformation_CategoryId",
                schema: "Identity",
                table: "CourseExtraInformation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExtraInformation_PartnerId",
                schema: "Identity",
                table: "CourseExtraInformation",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CourseContentId",
                schema: "Identity",
                table: "CourseSections",
                column: "CourseContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSource_CourseSectionsId",
                schema: "Identity",
                table: "CourseSource",
                column: "CourseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSource_CourseUploadId",
                schema: "Identity",
                table: "CourseSource",
                column: "CourseUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_File_AppUserId",
                schema: "Identity",
                table: "File",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveCourse_AppUserId",
                schema: "Identity",
                table: "InclusiveCourse",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveCourse_CourseBasicInformationId",
                schema: "Identity",
                table: "InclusiveCourse",
                column: "CourseBasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveCourse_CourseContentId",
                schema: "Identity",
                table: "InclusiveCourse",
                column: "CourseContentId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveCourse_CourseExtraInformationId",
                schema: "Identity",
                table: "InclusiveCourse",
                column: "CourseExtraInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveCourse_CoursePricingId",
                schema: "Identity",
                table: "InclusiveCourse",
                column: "CoursePricingId");

            migrationBuilder.CreateIndex(
                name: "IX_NewCoursePricingPlan_CoursePricingId",
                schema: "Identity",
                table: "NewCoursePricingPlan",
                column: "CoursePricingId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserId",
                schema: "Identity",
                table: "RefreshToken",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountEducations_AppUserId",
                schema: "Identity",
                table: "UserAccountEducations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountExperiences_AppUserId",
                schema: "Identity",
                table: "UserAccountExperiences",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInformation_AppUserId",
                schema: "Identity",
                table: "UserAccountInformation",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInformationAbout_AppUserId",
                schema: "Identity",
                table: "UserAccountInformationAbout",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_AllUserSkillsId",
                schema: "Identity",
                table: "UserSkills",
                column: "AllUserSkillsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_AppUserId",
                schema: "Identity",
                table: "UserSkills",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseSource",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InclusiveCourse",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "NewCoursePricingPlan",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserAccountEducations",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserAccountExperiences",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserAccountInformation",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserAccountInformationAbout",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSkills",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MetaData",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseSections",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseBasicInformation",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseExtraInformation",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CoursePricing",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AllUserSkills",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseContent",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "File",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");
        }
    }
}
