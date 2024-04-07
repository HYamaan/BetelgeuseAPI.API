using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetelgeuseAPI.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "CourseMessageToReviewer",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Rules = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMessageToReviewer", x => x.Id);
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeoCode = table.Column<string>(type: "text", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "CoursePricingNewPlan",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_CoursePricingNewPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePricingNewPlan_CoursePricing_CoursePricingId",
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
                        name: "FK_Blogs_MetaData_MetaDataId",
                        column: x => x.MetaDataId,
                        principalSchema: "Identity",
                        principalTable: "MetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    CourseBasicInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoursePricingId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageToReviewerId = table.Column<Guid>(type: "uuid", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_CourseMessageToReviewer_MessageToReviewerId",
                        column: x => x.MessageToReviewerId,
                        principalSchema: "Identity",
                        principalTable: "CourseMessageToReviewer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_CoursePricing_CoursePricingId",
                        column: x => x.CoursePricingId,
                        principalSchema: "Identity",
                        principalTable: "CoursePricing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
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
                    IsCertificate = table.Column<bool>(type: "boolean", nullable: false),
                    IsDownloadable = table.Column<bool>(type: "boolean", nullable: false),
                    IsPartnered = table.Column<bool>(type: "boolean", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    CourseLevel = table.Column<int>(type: "integer", nullable: false),
                    PartnerId = table.Column<string>(type: "text", nullable: true),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_CourseExtraInformation_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
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
                name: "CourseFaq",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFaq_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseFaqMaterial",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaqMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFaqMaterial_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseFaqRequirements",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaqRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFaqRequirements_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PassAllParts = table.Column<bool>(type: "boolean", nullable: false),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubLanguage",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    CourseExtraInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubLanguage_CourseExtraInformation_CourseExtraInforma~",
                        column: x => x.CourseExtraInformationId,
                        principalSchema: "Identity",
                        principalTable: "CourseExtraInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Identity",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseQuiz",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Attempts = table.Column<int>(type: "integer", nullable: true),
                    PassingScore = table.Column<int>(type: "integer", nullable: false),
                    ExpiryDate = table.Column<int>(type: "integer", nullable: true),
                    LimitedQuestion = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionCount = table.Column<int>(type: "integer", nullable: true),
                    RandomizeQuestion = table.Column<bool>(type: "boolean", nullable: false),
                    Certificate = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CourseSectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseQuiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseQuiz_CourseSections_CourseSectionsId",
                        column: x => x.CourseSectionsId,
                        principalSchema: "Identity",
                        principalTable: "CourseSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSource",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CourseSourcesId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseQuizzesId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseSectionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseType_CourseQuiz_CourseQuizzesId",
                        column: x => x.CourseQuizzesId,
                        principalSchema: "Identity",
                        principalTable: "CourseQuiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseType_CourseSections_CourseSectionsId",
                        column: x => x.CourseSectionsId,
                        principalSchema: "Identity",
                        principalTable: "CourseSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseType_CourseSource_CourseSourcesId",
                        column: x => x.CourseSourcesId,
                        principalSchema: "Identity",
                        principalTable: "CourseSource",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseBasicInformation",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "CourseQuestions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseQuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseQuestions_CourseQuiz_CourseQuizId",
                        column: x => x.CourseQuizId,
                        principalSchema: "Identity",
                        principalTable: "CourseQuiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseQuizAnswer",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CourseQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseQuizAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseQuizAnswer_CourseQuestions_CourseQuestionId",
                        column: x => x.CourseQuestionId,
                        principalSchema: "Identity",
                        principalTable: "CourseQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    CourseSourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseQuestionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    InclusiveCourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_CourseQuestions_CourseQuestionsId",
                        column: x => x.CourseQuestionsId,
                        principalSchema: "Identity",
                        principalTable: "CourseQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_CourseSource_CourseSourceId",
                        column: x => x.CourseSourceId,
                        principalSchema: "Identity",
                        principalTable: "CourseSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Course_InclusiveCourseId",
                        column: x => x.InclusiveCourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Language",
                columns: new[] { "Id", "IsPrimary", "Name", "Published", "SeoCode" },
                values: new object[,]
                {
                    { 1, true, "Türkçe", true, "tr" },
                    { 2, false, "İngilizce", true, "en" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d953260-69f6-4c94-9c21-1f1a4243fa0b", null, "Moderator", "MODERATOR" },
                    { "d1dfafb7-85c0-4a27-9660-1883f236c72a", null, "Student", "STUDENT" },
                    { "eeb12abb-2276-4e1d-8c46-ad01f6ac2077", null, "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4d953260-69f6-4c94-9c21-1f1a4243fa0b", 0, "44054acd-f22d-4090-ac29-bed6844ef366", "moderator@gmail.com", true, false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "moderator@gmail.com" },
                    { "d1dfafb7-85c0-4a27-9660-1883f236c72a", 0, "d30c49d1-f6df-4029-bbce-3594953b73fc", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4d953260-69f6-4c94-9c21-1f1a4243fa0b", "4d953260-69f6-4c94-9c21-1f1a4243fa0b" },
                    { "d1dfafb7-85c0-4a27-9660-1883f236c72a", "d1dfafb7-85c0-4a27-9660-1883f236c72a" }
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
                name: "IX_Course_AppUserId",
                schema: "Identity",
                table: "Course",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseBasicInformationId",
                schema: "Identity",
                table: "Course",
                column: "CourseBasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CoursePricingId",
                schema: "Identity",
                table: "Course",
                column: "CoursePricingId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_MessageToReviewerId",
                schema: "Identity",
                table: "Course",
                column: "MessageToReviewerId");

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
                name: "IX_CourseExtraInformation_InclusiveCourseId",
                schema: "Identity",
                table: "CourseExtraInformation",
                column: "InclusiveCourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseExtraInformation_PartnerId",
                schema: "Identity",
                table: "CourseExtraInformation",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFaq_InclusiveCourseId",
                schema: "Identity",
                table: "CourseFaq",
                column: "InclusiveCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFaqMaterial_InclusiveCourseId",
                schema: "Identity",
                table: "CourseFaqMaterial",
                column: "InclusiveCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFaqRequirements_InclusiveCourseId",
                schema: "Identity",
                table: "CourseFaqRequirements",
                column: "InclusiveCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePricingNewPlan_CoursePricingId",
                schema: "Identity",
                table: "CoursePricingNewPlan",
                column: "CoursePricingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuestions_CourseQuizId",
                schema: "Identity",
                table: "CourseQuestions",
                column: "CourseQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuestions_ImageId",
                schema: "Identity",
                table: "CourseQuestions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuiz_CourseSectionsId",
                schema: "Identity",
                table: "CourseQuiz",
                column: "CourseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuizAnswer_CourseQuestionId",
                schema: "Identity",
                table: "CourseQuizAnswer",
                column: "CourseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_InclusiveCourseId",
                schema: "Identity",
                table: "CourseSections",
                column: "InclusiveCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSource_CourseSectionsId",
                schema: "Identity",
                table: "CourseSource",
                column: "CourseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubLanguage_CourseExtraInformationId",
                schema: "Identity",
                table: "CourseSubLanguage",
                column: "CourseExtraInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubLanguage_LanguageId",
                schema: "Identity",
                table: "CourseSubLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseType_CourseQuizzesId",
                schema: "Identity",
                table: "CourseType",
                column: "CourseQuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseType_CourseSectionsId",
                schema: "Identity",
                table: "CourseType",
                column: "CourseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseType_CourseSourcesId",
                schema: "Identity",
                table: "CourseType",
                column: "CourseSourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_File_AppUserId",
                schema: "Identity",
                table: "File",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_CourseQuestionsId",
                schema: "Identity",
                table: "File",
                column: "CourseQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_File_CourseSourceId",
                schema: "Identity",
                table: "File",
                column: "CourseSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_File_InclusiveCourseId",
                schema: "Identity",
                table: "File",
                column: "InclusiveCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_AppUserId",
                schema: "Identity",
                table: "Purchase",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_InclusiveCourseId",
                schema: "Identity",
                table: "Purchase",
                column: "InclusiveCourseId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_File_BlogImageID",
                schema: "Identity",
                table: "Blogs",
                column: "BlogImageID",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseBasicInformation_CourseBasicInformationId",
                schema: "Identity",
                table: "Course",
                column: "CourseBasicInformationId",
                principalSchema: "Identity",
                principalTable: "CourseBasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseBasicInformation_File_CoverImageId",
                schema: "Identity",
                table: "CourseBasicInformation",
                column: "CoverImageId",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseBasicInformation_File_ThumbnailId",
                schema: "Identity",
                table: "CourseBasicInformation",
                column: "ThumbnailId",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseQuestions_File_ImageId",
                schema: "Identity",
                table: "CourseQuestions",
                column: "ImageId",
                principalSchema: "Identity",
                principalTable: "File",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseBasicInformation_File_CoverImageId",
                schema: "Identity",
                table: "CourseBasicInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseBasicInformation_File_ThumbnailId",
                schema: "Identity",
                table: "CourseBasicInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseQuestions_File_ImageId",
                schema: "Identity",
                table: "CourseQuestions");

            migrationBuilder.DropTable(
                name: "Blogs",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseFaq",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseFaqMaterial",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseFaqRequirements",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CoursePricingNewPlan",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseQuizAnswer",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseSubLanguage",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseType",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Purchase",
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
                name: "CourseExtraInformation",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AllUserSkills",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "File",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseQuestions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseSource",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseQuiz",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseSections",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseBasicInformation",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseMessageToReviewer",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CoursePricing",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");
        }
    }
}
