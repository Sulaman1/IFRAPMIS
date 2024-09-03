using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToolAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "CommunityTypes",
                columns: table => new
                {
                    CommunityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTypes", x => x.CommunityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DamageAssessmentHTSs",
                columns: table => new
                {
                    DamageAssessmentHTSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageAssessmentHTSType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageAssessmentHTSs", x => x.DamageAssessmentHTSId);
                });

            migrationBuilder.CreateTable(
                name: "DamageAssessmentLivestocks",
                columns: table => new
                {
                    DamageAssessmentLivestockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageAssessmentLivestockType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageAssessmentLivestocks", x => x.DamageAssessmentLivestockId);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    PhaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.PhaseId);
                });

            migrationBuilder.CreateTable(
                name: "Proviences",
                columns: table => new
                {
                    ProvienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proviences", x => x.ProvienceId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingHeads",
                columns: table => new
                {
                    TrainingHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingHeadCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingHeads", x => x.TrainingHeadId);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Proviences",
                        principalColumn: "ProvienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTitles",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingTitleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingHeadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTitles", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_TrainingTitles_TrainingHeads_TrainingHeadId",
                        column: x => x.TrainingHeadId,
                        principalTable: "TrainingHeads",
                        principalColumn: "TrainingHeadId");
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tehsils",
                columns: table => new
                {
                    TehsilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TehsilName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehsils", x => x.TehsilId);
                    table.ForeignKey(
                        name: "FK_Tehsils_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_Trainers_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId");
                    table.ForeignKey(
                        name: "FK_Trainers_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnionCouncils",
                columns: table => new
                {
                    UnionCouncilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnionCouncilName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TehsilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionCouncils", x => x.UnionCouncilId);
                    table.ForeignKey(
                        name: "FK_UnionCouncils_Tehsils_TehsilId",
                        column: x => x.TehsilId,
                        principalTable: "Tehsils",
                        principalColumn: "TehsilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    VillageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.VillageId);
                    table.ForeignKey(
                        name: "FK_Villages_UnionCouncils_UnionCouncilId",
                        column: x => x.UnionCouncilId,
                        principalTable: "UnionCouncils",
                        principalColumn: "UnionCouncilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryIPs",
                columns: table => new
                {
                    BeneficiaryIPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MaritialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisable = table.Column<bool>(type: "bit", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRefugee = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryIPs", x => x.BeneficiaryIPId);
                    table.ForeignKey(
                        name: "FK_BeneficiaryIPs_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryPDMAs",
                columns: table => new
                {
                    BeneficiaryPDMAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MaritialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisable = table.Column<bool>(type: "bit", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRefugee = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryPDMAs", x => x.BeneficiaryPDMAId);
                    table.ForeignKey(
                        name: "FK_BeneficiaryPDMAs_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
                });

            migrationBuilder.CreateTable(
                name: "CICIGs",
                columns: table => new
                {
                    CICIGId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HouseHoldNumber = table.Column<int>(type: "int", nullable: false),
                    HouseHoldParticipated = table.Column<int>(type: "int", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: true),
                    RejectedComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmittedForReview = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedForReviewBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedForReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectionFormAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageProfileAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOPAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: true),
                    CommunityTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGs", x => x.CICIGId);
                    table.ForeignKey(
                        name: "FK_CICIGs_CommunityTypes_CommunityTypeId",
                        column: x => x.CommunityTypeId,
                        principalTable: "CommunityTypes",
                        principalColumn: "CommunityTypeId");
                    table.ForeignKey(
                        name: "FK_CICIGs_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId");
                    table.ForeignKey(
                        name: "FK_CICIGs_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CICIGTrainings",
                columns: table => new
                {
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingTitleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingHeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMembersParticipated = table.Column<int>(type: "int", nullable: true),
                    TotalNumberMale = table.Column<int>(type: "int", nullable: true),
                    TotalNumberFemale = table.Column<int>(type: "int", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: true),
                    TotalClasses = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionPlanAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAttachment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAttachment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAttachment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAttachment4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    TrainingHeadId = table.Column<int>(type: "int", nullable: true),
                    TrainingTitleId = table.Column<int>(type: "int", nullable: true),
                    PhaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGTrainings", x => x.CICIGTrainingsId);
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId");
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_TrainingHeads_TrainingHeadId",
                        column: x => x.TrainingHeadId,
                        principalTable: "TrainingHeads",
                        principalColumn: "TrainingHeadId");
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_TrainingTitles_TrainingTitleId",
                        column: x => x.TrainingTitleId,
                        principalTable: "TrainingTitles",
                        principalColumn: "TitleId");
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
                });

            migrationBuilder.CreateTable(
                name: "DamageIPs",
                columns: table => new
                {
                    DamageIPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryIPId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentHTSId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentLivestockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageIPs", x => x.DamageIPId);
                    table.ForeignKey(
                        name: "FK_DamageIPs_BeneficiaryIPs_BeneficiaryIPId",
                        column: x => x.BeneficiaryIPId,
                        principalTable: "BeneficiaryIPs",
                        principalColumn: "BeneficiaryIPId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageIPs_DamageAssessmentHTSs_DamageAssessmentHTSId",
                        column: x => x.DamageAssessmentHTSId,
                        principalTable: "DamageAssessmentHTSs",
                        principalColumn: "DamageAssessmentHTSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageIPs_DamageAssessmentLivestocks_DamageAssessmentLivestockId",
                        column: x => x.DamageAssessmentLivestockId,
                        principalTable: "DamageAssessmentLivestocks",
                        principalColumn: "DamageAssessmentLivestockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamagePDMAs",
                columns: table => new
                {
                    DamagePDMAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryPDMAId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentHTSId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentLivestockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamagePDMAs", x => x.DamagePDMAId);
                    table.ForeignKey(
                        name: "FK_DamagePDMAs_BeneficiaryPDMAs_BeneficiaryPDMAId",
                        column: x => x.BeneficiaryPDMAId,
                        principalTable: "BeneficiaryPDMAs",
                        principalColumn: "BeneficiaryPDMAId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamagePDMAs_DamageAssessmentHTSs_DamageAssessmentHTSId",
                        column: x => x.DamageAssessmentHTSId,
                        principalTable: "DamageAssessmentHTSs",
                        principalColumn: "DamageAssessmentHTSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamagePDMAs_DamageAssessmentLivestocks_DamageAssessmentLivestockId",
                        column: x => x.DamageAssessmentLivestockId,
                        principalTable: "DamageAssessmentLivestocks",
                        principalColumn: "DamageAssessmentLivestockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CIMembers",
                columns: table => new
                {
                    CIMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CICIGId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIMembers", x => x.CIMemberId);
                    table.ForeignKey(
                        name: "FK_CIMembers_CICIGs_CICIGId",
                        column: x => x.CICIGId,
                        principalTable: "CICIGs",
                        principalColumn: "CICIGId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CICIGTrainingTrainer",
                columns: table => new
                {
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGTrainingTrainer", x => new { x.CICIGTrainingsId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_CICIGTrainingTrainer_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CICIGTrainingTrainer_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITrainingParticipations",
                columns: table => new
                {
                    CIIrainingParticipationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CICIGId = table.Column<int>(type: "int", nullable: false),
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITrainingParticipations", x => x.CIIrainingParticipationId);
                    table.ForeignKey(
                        name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CITrainingParticipations_CICIGs_CICIGId",
                        column: x => x.CICIGId,
                        principalTable: "CICIGs",
                        principalColumn: "CICIGId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryVerifieds",
                columns: table => new
                {
                    BeneficiaryVerifiedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MaritialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisable = table.Column<bool>(type: "bit", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRefugee = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIMemberId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryIPId = table.Column<int>(type: "int", nullable: true),
                    BeneficiaryPDMAId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryVerifieds", x => x.BeneficiaryVerifiedId);
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_BeneficiaryIPs_BeneficiaryIPId",
                        column: x => x.BeneficiaryIPId,
                        principalTable: "BeneficiaryIPs",
                        principalColumn: "BeneficiaryIPId");
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_BeneficiaryPDMAs_BeneficiaryPDMAId",
                        column: x => x.BeneficiaryPDMAId,
                        principalTable: "BeneficiaryPDMAs",
                        principalColumn: "BeneficiaryPDMAId");
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_CIMembers_CIMemberId",
                        column: x => x.CIMemberId,
                        principalTable: "CIMembers",
                        principalColumn: "CIMemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
                });

            migrationBuilder.CreateTable(
                name: "CITrainingMembers",
                columns: table => new
                {
                    CITrainingMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIMemberId = table.Column<int>(type: "int", nullable: false),
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITrainingMembers", x => x.CITrainingMemberId);
                    table.ForeignKey(
                        name: "FK_CITrainingMembers_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CITrainingMembers_CIMembers_CIMemberId",
                        column: x => x.CIMemberId,
                        principalTable: "CIMembers",
                        principalColumn: "CIMemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamageVerifieds",
                columns: table => new
                {
                    DamageVerifiedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryVerifiedId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentHTSId = table.Column<int>(type: "int", nullable: false),
                    DamageAssessmentLivestockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageVerifieds", x => x.DamageVerifiedId);
                    table.ForeignKey(
                        name: "FK_DamageVerifieds_BeneficiaryVerifieds_BeneficiaryVerifiedId",
                        column: x => x.BeneficiaryVerifiedId,
                        principalTable: "BeneficiaryVerifieds",
                        principalColumn: "BeneficiaryVerifiedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageVerifieds_DamageAssessmentHTSs_DamageAssessmentHTSId",
                        column: x => x.DamageAssessmentHTSId,
                        principalTable: "DamageAssessmentHTSs",
                        principalColumn: "DamageAssessmentHTSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageVerifieds_DamageAssessmentLivestocks_DamageAssessmentLivestockId",
                        column: x => x.DamageAssessmentLivestockId,
                        principalTable: "DamageAssessmentLivestocks",
                        principalColumn: "DamageAssessmentLivestockId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryIPs_VillageId",
                table: "BeneficiaryIPs",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryPDMAs_VillageId",
                table: "BeneficiaryPDMAs",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_BeneficiaryIPId",
                table: "BeneficiaryVerifieds",
                column: "BeneficiaryIPId",
                unique: true,
                filter: "[BeneficiaryIPId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds",
                column: "BeneficiaryPDMAId",
                unique: true,
                filter: "[BeneficiaryPDMAId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_CIMemberId",
                table: "BeneficiaryVerifieds",
                column: "CIMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_VillageId",
                table: "BeneficiaryVerifieds",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_CommunityTypeId",
                table: "CICIGs",
                column: "CommunityTypeId",
                unique: true,
                filter: "[CommunityTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_VillageId",
                table: "CICIGs",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings",
                column: "TrainingHeadId",
                unique: true,
                filter: "[TrainingHeadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId",
                unique: true,
                filter: "[TrainingTitleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_VillageId",
                table: "CICIGTrainings",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainingTrainer_TrainerId",
                table: "CICIGTrainingTrainer",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CIMembers_CICIGId",
                table: "CIMembers",
                column: "CICIGId");

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingMembers_CICIGTrainingsId",
                table: "CITrainingMembers",
                column: "CICIGTrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingMembers_CIMemberId",
                table: "CITrainingMembers",
                column: "CIMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGId",
                table: "CITrainingParticipations",
                column: "CICIGId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageIPs_BeneficiaryIPId",
                table: "DamageIPs",
                column: "BeneficiaryIPId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageIPs_DamageAssessmentHTSId",
                table: "DamageIPs",
                column: "DamageAssessmentHTSId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageIPs_DamageAssessmentLivestockId",
                table: "DamageIPs",
                column: "DamageAssessmentLivestockId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagePDMAs_BeneficiaryPDMAId",
                table: "DamagePDMAs",
                column: "BeneficiaryPDMAId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagePDMAs_DamageAssessmentHTSId",
                table: "DamagePDMAs",
                column: "DamageAssessmentHTSId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagePDMAs_DamageAssessmentLivestockId",
                table: "DamagePDMAs",
                column: "DamageAssessmentLivestockId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageVerifieds_BeneficiaryVerifiedId",
                table: "DamageVerifieds",
                column: "BeneficiaryVerifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageVerifieds_DamageAssessmentHTSId",
                table: "DamageVerifieds",
                column: "DamageAssessmentHTSId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageVerifieds_DamageAssessmentLivestockId",
                table: "DamageVerifieds",
                column: "DamageAssessmentLivestockId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tehsils_DistrictId",
                table: "Tehsils",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_DistrictId",
                table: "Trainers",
                column: "DistrictId",
                unique: true,
                filter: "[DistrictId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SectionId",
                table: "Trainers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTitles_TrainingHeadId",
                table: "TrainingTitles",
                column: "TrainingHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_UnionCouncils_TehsilId",
                table: "UnionCouncils",
                column: "TehsilId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_UnionCouncilId",
                table: "Villages",
                column: "UnionCouncilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CICIGTrainingTrainer");

            migrationBuilder.DropTable(
                name: "CITrainingMembers");

            migrationBuilder.DropTable(
                name: "CITrainingParticipations");

            migrationBuilder.DropTable(
                name: "DamageIPs");

            migrationBuilder.DropTable(
                name: "DamagePDMAs");

            migrationBuilder.DropTable(
                name: "DamageVerifieds");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "CICIGTrainings");

            migrationBuilder.DropTable(
                name: "BeneficiaryVerifieds");

            migrationBuilder.DropTable(
                name: "DamageAssessmentHTSs");

            migrationBuilder.DropTable(
                name: "DamageAssessmentLivestocks");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "TrainingTitles");

            migrationBuilder.DropTable(
                name: "BeneficiaryIPs");

            migrationBuilder.DropTable(
                name: "BeneficiaryPDMAs");

            migrationBuilder.DropTable(
                name: "CIMembers");

            migrationBuilder.DropTable(
                name: "TrainingHeads");

            migrationBuilder.DropTable(
                name: "CICIGs");

            migrationBuilder.DropTable(
                name: "CommunityTypes");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "UnionCouncils");

            migrationBuilder.DropTable(
                name: "Tehsils");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Proviences");
        }
    }
}
