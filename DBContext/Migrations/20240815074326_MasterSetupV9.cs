using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingTitle_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingTitle");

            migrationBuilder.DropIndex(
                name: "IX_TrainingTitle_CICIGTrainingsId",
                table: "TrainingTitle");

            migrationBuilder.DropIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "CICIGTrainingsId",
                table: "TrainingTitle");

            migrationBuilder.DropColumn(
                name: "DisabilityType",
                table: "BeneficiaryVerifieds");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingName",
                table: "TrainingTitle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingIntervention",
                table: "TrainingTitle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainingIntervention",
                table: "TrainingHeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CIMemberId",
                table: "CITrainingMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingTitleId",
                table: "CICIGTrainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryIPId",
                table: "BeneficiaryVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "BeneficiaryVerifieds",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefugee",
                table: "BeneficiaryVerifieds",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingMembers_CIMemberId",
                table: "CITrainingMembers",
                column: "CIMemberId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_BeneficiaryIPs_BeneficiaryIPId",
                table: "BeneficiaryVerifieds",
                column: "BeneficiaryIPId",
                principalTable: "BeneficiaryIPs",
                principalColumn: "BeneficiaryIPId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_BeneficiaryPDMAs_BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds",
                column: "BeneficiaryPDMAId",
                principalTable: "BeneficiaryPDMAs",
                principalColumn: "BeneficiaryPDMAId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_TrainingTitle_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId",
                principalTable: "TrainingTitle",
                principalColumn: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CITrainingMembers_CIMembers_CIMemberId",
                table: "CITrainingMembers",
                column: "CIMemberId",
                principalTable: "CIMembers",
                principalColumn: "CIMemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_BeneficiaryIPs_BeneficiaryIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_BeneficiaryPDMAs_BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_TrainingTitle_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_CITrainingMembers_CIMembers_CIMemberId",
                table: "CITrainingMembers");

            migrationBuilder.DropIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.DropIndex(
                name: "IX_CITrainingMembers_CIMemberId",
                table: "CITrainingMembers");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryVerifieds_BeneficiaryIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryVerifieds_BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "TrainingIntervention",
                table: "TrainingTitle");

            migrationBuilder.DropColumn(
                name: "TrainingIntervention",
                table: "TrainingHeads");

            migrationBuilder.DropColumn(
                name: "CIMemberId",
                table: "CITrainingMembers");

            migrationBuilder.DropColumn(
                name: "TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "BeneficiaryIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPDMAId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "IsRefugee",
                table: "BeneficiaryVerifieds");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingName",
                table: "TrainingTitle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "TrainingTitle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityType",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTitle_CICIGTrainingsId",
                table: "TrainingTitle",
                column: "CICIGTrainingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings",
                column: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingTitle_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingTitle",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
