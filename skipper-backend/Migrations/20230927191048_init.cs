using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelOfExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOfExperience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilizationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BillingPerHour = table.Column<double>(type: "float", nullable: true),
                    FixedSalaryGross = table.Column<double>(type: "float", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillsMatrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProjectLeadId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProject_AspNetUsers_ProjectLeadId",
                        column: x => x.ProjectLeadId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rgb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CV_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguage_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguage_LanguageLevel_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositionAndLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelOfExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositionAndLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePositionAndLevel_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositionAndLevel_LevelOfExperience_LevelOfExperienceId",
                        column: x => x.LevelOfExperienceId,
                        principalTable: "LevelOfExperience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositionAndLevel_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiringPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtilizationAmount = table.Column<double>(type: "float", nullable: false),
                    EmployeeLevelOfExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<double>(type: "float", nullable: true),
                    PrefferedStart = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringPost_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiringPost_LevelOfExperience_EmployeeLevelOfExperienceId",
                        column: x => x.EmployeeLevelOfExperienceId,
                        principalTable: "LevelOfExperience",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HiringPost_UtilizationType_UtilizationTypeId",
                        column: x => x.UtilizationTypeId,
                        principalTable: "UtilizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Line_AspNetUsers_LineManagerId",
                        column: x => x.LineManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsMatrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rgb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsMatrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsMatrix_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rgb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProjectFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProjectFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProjectFile_CompanyProject_CompanyProjectId",
                        column: x => x.CompanyProjectId,
                        principalTable: "CompanyProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectComment_AspNetUsers_CommentorId",
                        column: x => x.CommentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectComment_CompanyProject_CompanyProjectId",
                        column: x => x.CompanyProjectId,
                        principalTable: "CompanyProject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTag_CompanyProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "CompanyProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CVItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CVId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationExperienceOrCert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVItem_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiringPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralSkill_HiringPost_HiringPostId",
                        column: x => x.HiringPostId,
                        principalTable: "HiringPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HiringPostApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    HiringPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringPostApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringPostApplication_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiringPostApplication_HiringPost_HiringPostId",
                        column: x => x.HiringPostId,
                        principalTable: "HiringPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HiringPostComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HiringPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringPostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringPostComment_AspNetUsers_CommentorId",
                        column: x => x.CommentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiringPostComment_HiringPost_HiringPostId",
                        column: x => x.HiringPostId,
                        principalTable: "HiringPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HiringPostFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiringPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringPostFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringPostFile_HiringPost_HiringPostId",
                        column: x => x.HiringPostId,
                        principalTable: "HiringPost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HiringPostRequiredLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HiringPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringPostRequiredLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringPostRequiredLanguage_HiringPost_HiringPostId",
                        column: x => x.HiringPostId,
                        principalTable: "HiringPost",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HiringPostRequiredLanguage_LanguageLevel_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiringPostRequiredLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsMatrixInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillsMatrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsMatrixInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsMatrixInput_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsMatrixInput_SkillsMatrix_SkillsMatrixId",
                        column: x => x.SkillsMatrixId,
                        principalTable: "SkillsMatrix",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillsMatrixSingleSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeTo = table.Column<int>(type: "int", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsMatrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsMatrixSingleSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsMatrixSingleSkill_SkillsMatrix_SkillsMatrixId",
                        column: x => x.SkillsMatrixId,
                        principalTable: "SkillsMatrix",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Checkbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkbox_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberInput_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radio_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RadioGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadioGroup_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    AllowHalf = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectMultiple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectMultiple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectMultiple_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectSingle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectSingle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectSingle_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    LabelLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slider_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAssignee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASssigneeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAssignee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAssignee_AspNetUsers_ASssigneeId",
                        column: x => x.ASssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyAssignee_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespondentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyInput_AspNetUsers_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyInput_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextArea_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextInput_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeneralSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_GeneralSkill_GeneralSkillId",
                        column: x => x.GeneralSkillId,
                        principalTable: "GeneralSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsMatrixSingleSkillInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input = table.Column<int>(type: "int", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    SkillsMatrixInputId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsMatrixSingleSkillInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsMatrixSingleSkillInput_SkillsMatrixInput_SkillsMatrixInputId",
                        column: x => x.SkillsMatrixInputId,
                        principalTable: "SkillsMatrixInput",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadioGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SelectMultipleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SelectSingleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputOptions_RadioGroup_RadioGroupId",
                        column: x => x.RadioGroupId,
                        principalTable: "RadioGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputOptions_SelectMultiple_SelectMultipleId",
                        column: x => x.SelectMultipleId,
                        principalTable: "SelectMultiple",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputOptions_SelectSingle_SelectSingleId",
                        column: x => x.SelectSingleId,
                        principalTable: "SelectSingle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderKey = table.Column<int>(type: "int", nullable: false),
                    CheckboxOrRadio = table.Column<bool>(type: "bit", nullable: true),
                    TextInputOrArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputNumberOrRateOrSlider = table.Column<double>(type: "float", nullable: true),
                    RadioGroupOrSingleSelectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyInputId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_InputOptions_RadioGroupOrSingleSelectId",
                        column: x => x.RadioGroupOrSingleSelectId,
                        principalTable: "InputOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_SurveyInput_SurveyInputId",
                        column: x => x.SurveyInputId,
                        principalTable: "SurveyInput",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03bf6d87-d2a8-442a-93a8-25629ed5e45d", null, "Member", "MEMBER" },
                    { "6c61d459-7d7e-4b95-9a6a-ac1dcd1bea54", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LineId",
                table: "AspNetUsers",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SkillsMatrixId",
                table: "AspNetUsers",
                column: "SkillsMatrixId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Checkbox_SurveyId",
                table: "Checkbox",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProject_ProjectLeadId",
                table: "CompanyProject",
                column: "ProjectLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProjectFile_CompanyProjectId",
                table: "CompanyProjectFile",
                column: "CompanyProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_OwnerId",
                table: "CV",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CVItem_CVId",
                table: "CVItem",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguage_EmployeeId",
                table: "EmployeeLanguage",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguage_LanguageId",
                table: "EmployeeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguage_LanguageLevelId",
                table: "EmployeeLanguage",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositionAndLevel_EmployeeId",
                table: "EmployeePositionAndLevel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositionAndLevel_LevelOfExperienceId",
                table: "EmployeePositionAndLevel",
                column: "LevelOfExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositionAndLevel_PositionId",
                table: "EmployeePositionAndLevel",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_GeneralSkillId",
                table: "EmployeeSkill",
                column: "GeneralSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSkill_HiringPostId",
                table: "GeneralSkill",
                column: "HiringPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_UserId",
                table: "Goal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPost_CreatorId",
                table: "HiringPost",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPost_EmployeeLevelOfExperienceId",
                table: "HiringPost",
                column: "EmployeeLevelOfExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPost_UtilizationTypeId",
                table: "HiringPost",
                column: "UtilizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostApplication_ApplicantId",
                table: "HiringPostApplication",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostApplication_HiringPostId",
                table: "HiringPostApplication",
                column: "HiringPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostComment_CommentorId",
                table: "HiringPostComment",
                column: "CommentorId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostComment_HiringPostId",
                table: "HiringPostComment",
                column: "HiringPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostFile_HiringPostId",
                table: "HiringPostFile",
                column: "HiringPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostRequiredLanguage_HiringPostId",
                table: "HiringPostRequiredLanguage",
                column: "HiringPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostRequiredLanguage_LanguageId",
                table: "HiringPostRequiredLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringPostRequiredLanguage_LanguageLevelId",
                table: "HiringPostRequiredLanguage",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_InputOptions_RadioGroupId",
                table: "InputOptions",
                column: "RadioGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputOptions_SelectMultipleId",
                table: "InputOptions",
                column: "SelectMultipleId");

            migrationBuilder.CreateIndex(
                name: "IX_InputOptions_SelectSingleId",
                table: "InputOptions",
                column: "SelectSingleId");

            migrationBuilder.CreateIndex(
                name: "IX_InputOptions_SurveyAnswerId",
                table: "InputOptions",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_LineManagerId",
                table: "Line",
                column: "LineManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberInput_SurveyId",
                table: "NumberInput",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_CommentorId",
                table: "ProjectComment",
                column: "CommentorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_CompanyProjectId",
                table: "ProjectComment",
                column: "CompanyProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_ProjectId",
                table: "ProjectTag",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_SurveyId",
                table: "Radio",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_RadioGroup_SurveyId",
                table: "RadioGroup",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_SurveyId",
                table: "Rate",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectMultiple_SurveyId",
                table: "SelectMultiple",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSingle_SurveyId",
                table: "SelectSingle",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMatrix_CreatorId",
                table: "SkillsMatrix",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMatrixInput_AssigneeId",
                table: "SkillsMatrixInput",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMatrixInput_SkillsMatrixId",
                table: "SkillsMatrixInput",
                column: "SkillsMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMatrixSingleSkill_SkillsMatrixId",
                table: "SkillsMatrixSingleSkill",
                column: "SkillsMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsMatrixSingleSkillInput_SkillsMatrixInputId",
                table: "SkillsMatrixSingleSkillInput",
                column: "SkillsMatrixInputId");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_SurveyId",
                table: "Slider",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_CreatorId",
                table: "Survey",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_RadioGroupOrSingleSelectId",
                table: "SurveyAnswer",
                column: "RadioGroupOrSingleSelectId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyInputId",
                table: "SurveyAnswer",
                column: "SurveyInputId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAssignee_ASssigneeId",
                table: "SurveyAssignee",
                column: "ASssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAssignee_SurveyId",
                table: "SurveyAssignee",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyInput_RespondentId",
                table: "SurveyInput",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyInput_SurveyId",
                table: "SurveyInput",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_TextArea_SurveyId",
                table: "TextArea",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_TextInput_SurveyId",
                table: "TextInput",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Line_LineId",
                table: "AspNetUsers",
                column: "LineId",
                principalTable: "Line",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SkillsMatrix_SkillsMatrixId",
                table: "AspNetUsers",
                column: "SkillsMatrixId",
                principalTable: "SkillsMatrix",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputOptions_SurveyAnswer_SurveyAnswerId",
                table: "InputOptions",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_AspNetUsers_LineManagerId",
                table: "Line");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsMatrix_AspNetUsers_CreatorId",
                table: "SkillsMatrix");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_AspNetUsers_CreatorId",
                table: "Survey");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyInput_AspNetUsers_RespondentId",
                table: "SurveyInput");

            migrationBuilder.DropForeignKey(
                name: "FK_RadioGroup_Survey_SurveyId",
                table: "RadioGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectMultiple_Survey_SurveyId",
                table: "SelectMultiple");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSingle_Survey_SurveyId",
                table: "SelectSingle");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyInput_Survey_SurveyId",
                table: "SurveyInput");

            migrationBuilder.DropForeignKey(
                name: "FK_InputOptions_RadioGroup_RadioGroupId",
                table: "InputOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_InputOptions_SelectMultiple_SelectMultipleId",
                table: "InputOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_InputOptions_SelectSingle_SelectSingleId",
                table: "InputOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_InputOptions_SurveyAnswer_SurveyAnswerId",
                table: "InputOptions");

            migrationBuilder.DropTable(
                name: "AppPreferences");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Checkbox");

            migrationBuilder.DropTable(
                name: "CompanyProjectFile");

            migrationBuilder.DropTable(
                name: "CVItem");

            migrationBuilder.DropTable(
                name: "EmployeeLanguage");

            migrationBuilder.DropTable(
                name: "EmployeePositionAndLevel");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "HiringPostApplication");

            migrationBuilder.DropTable(
                name: "HiringPostComment");

            migrationBuilder.DropTable(
                name: "HiringPostFile");

            migrationBuilder.DropTable(
                name: "HiringPostRequiredLanguage");

            migrationBuilder.DropTable(
                name: "NumberInput");

            migrationBuilder.DropTable(
                name: "ProjectComment");

            migrationBuilder.DropTable(
                name: "ProjectTag");

            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "SkillsMatrixSingleSkill");

            migrationBuilder.DropTable(
                name: "SkillsMatrixSingleSkillInput");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "SurveyAssignee");

            migrationBuilder.DropTable(
                name: "TextArea");

            migrationBuilder.DropTable(
                name: "TextInput");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "GeneralSkill");

            migrationBuilder.DropTable(
                name: "LanguageLevel");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "CompanyProject");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "SkillsMatrixInput");

            migrationBuilder.DropTable(
                name: "HiringPost");

            migrationBuilder.DropTable(
                name: "LevelOfExperience");

            migrationBuilder.DropTable(
                name: "UtilizationType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "SkillsMatrix");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "RadioGroup");

            migrationBuilder.DropTable(
                name: "SelectMultiple");

            migrationBuilder.DropTable(
                name: "SelectSingle");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "InputOptions");

            migrationBuilder.DropTable(
                name: "SurveyInput");
        }
    }
}
