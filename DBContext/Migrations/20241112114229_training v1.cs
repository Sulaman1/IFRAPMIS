using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class trainingv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechTrainings",
                columns: table => new
                {
                    TechTrainingId = table.Column<int>(type: "int", nullable: false)
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
                    TechTrainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    TrainingTitleId = table.Column<int>(type: "int", nullable: true),
                    PhaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechTrainings", x => x.TechTrainingId);
                    table.ForeignKey(
                        name: "FK_TechTrainings_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "PhaseId");
                    table.ForeignKey(
                        name: "FK_TechTrainings_TrainingTitles_TrainingTitleId",
                        column: x => x.TrainingTitleId,
                        principalTable: "TrainingTitles",
                        principalColumn: "TitleId");
                    table.ForeignKey(
                        name: "FK_TechTrainings_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "VillageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechTrainingMembers",
                columns: table => new
                {
                    TechTrainingMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryTrainingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EducationDocAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNICAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionFormAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PWD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelfEmployed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredSkill1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredSkill2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredSkill3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredSkill4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechTrainingId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryVerifiedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechTrainingMembers", x => x.TechTrainingMemberId);
                    table.ForeignKey(
                        name: "FK_TechTrainingMembers_BeneficiaryVerifieds_BeneficiaryVerifiedId",
                        column: x => x.BeneficiaryVerifiedId,
                        principalTable: "BeneficiaryVerifieds",
                        principalColumn: "BeneficiaryVerifiedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechTrainingMembers_TechTrainings_TechTrainingId",
                        column: x => x.TechTrainingId,
                        principalTable: "TechTrainings",
                        principalColumn: "TechTrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechTrainingTrainer",
                columns: table => new
                {
                    TechTrainingsId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechTrainingTrainer", x => new { x.TechTrainingsId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_TechTrainingTrainer_TechTrainings_TechTrainingsId",
                        column: x => x.TechTrainingsId,
                        principalTable: "TechTrainings",
                        principalColumn: "TechTrainingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechTrainingTrainer_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainingMembers_BeneficiaryVerifiedId",
                table: "TechTrainingMembers",
                column: "BeneficiaryVerifiedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainingMembers_TechTrainingId",
                table: "TechTrainingMembers",
                column: "TechTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainings_PhaseId",
                table: "TechTrainings",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainings_TrainingTitleId",
                table: "TechTrainings",
                column: "TrainingTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainings_VillageId",
                table: "TechTrainings",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_TechTrainingTrainer_TrainerId",
                table: "TechTrainingTrainer",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechTrainingMembers");

            migrationBuilder.DropTable(
                name: "TechTrainingTrainer");

            migrationBuilder.DropTable(
                name: "TechTrainings");
        }
    }
}
