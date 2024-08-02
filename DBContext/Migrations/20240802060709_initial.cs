using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    DistrictId = table.Column<int>(type: "int", nullable: true),
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
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
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
                name: "Teshsils",
                columns: table => new
                {
                    TehsilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TehsilName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teshsils", x => x.TehsilId);
                    table.ForeignKey(
                        name: "FK_Teshsils_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
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
                        name: "FK_UnionCouncils_Teshsils_TehsilId",
                        column: x => x.TehsilId,
                        principalTable: "Teshsils",
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
                    DisabilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    DisabilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    VerifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachement1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachement2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachement3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tehsil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnionCouncil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGs", x => x.CICIGId);
                    table.ForeignKey(
                        name: "FK_CICIGs_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId",
                        onDelete: ReferentialAction.Cascade);
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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMembersParticipated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNumberMale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNumberFemale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attachment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    CICIGId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGTrainings", x => x.CICIGTrainingsId);
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_CICIGs_CICIGId",
                        column: x => x.CICIGId,
                        principalTable: "CICIGs",
                        principalColumn: "CICIGId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CICIGTrainings_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
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
                name: "CITrainingParticipations",
                columns: table => new
                {
                    CIIrainingParticipationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CICIGId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITrainingParticipations", x => x.CIIrainingParticipationId);
                    table.ForeignKey(
                        name: "FK_CITrainingParticipations_CICIGs_CICIGId",
                        column: x => x.CICIGId,
                        principalTable: "CICIGs",
                        principalColumn: "CICIGId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITrainingMembers",
                columns: table => new
                {
                    CITrainingMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    DisabilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CICIGId = table.Column<int>(type: "int", nullable: false),
                    CIMemberId = table.Column<int>(type: "int", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryVerifieds", x => x.BeneficiaryVerifiedId);
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_CICIGs_CICIGId",
                        column: x => x.CICIGId,
                        principalTable: "CICIGs",
                        principalColumn: "CICIGId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_CIMembers_CIMemberId",
                        column: x => x.CIMemberId,
                        principalTable: "CIMembers",
                        principalColumn: "CIMemberId");
                    table.ForeignKey(
                        name: "FK_BeneficiaryVerifieds_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId");
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
                name: "IX_BeneficiaryVerifieds_CICIGId",
                table: "BeneficiaryVerifieds",
                column: "CICIGId");

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
                name: "IX_CICIGs_VillageId",
                table: "CICIGs",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_CICIGId",
                table: "CICIGTrainings",
                column: "CICIGId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_VillageId",
                table: "CICIGTrainings",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_CIMembers_CICIGId",
                table: "CIMembers",
                column: "CICIGId");

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingMembers_CICIGTrainingsId",
                table: "CITrainingMembers",
                column: "CICIGTrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGId",
                table: "CITrainingParticipations",
                column: "CICIGId",
                unique: true);

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
                name: "IX_Teshsils_DistrictId",
                table: "Teshsils",
                column: "DistrictId");

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
                name: "CICIGTrainings");

            migrationBuilder.DropTable(
                name: "BeneficiaryIPs");

            migrationBuilder.DropTable(
                name: "BeneficiaryPDMAs");

            migrationBuilder.DropTable(
                name: "BeneficiaryVerifieds");

            migrationBuilder.DropTable(
                name: "DamageAssessmentHTSs");

            migrationBuilder.DropTable(
                name: "DamageAssessmentLivestocks");

            migrationBuilder.DropTable(
                name: "CIMembers");

            migrationBuilder.DropTable(
                name: "CICIGs");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "UnionCouncils");

            migrationBuilder.DropTable(
                name: "Teshsils");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
