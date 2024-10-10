using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class DamageTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "DamageVerifieds",
                newName: "DamageAssessmentBuildingId");

            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "DamageVerifieds",
                newName: "OtherTreeName");

            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "DamagePDMAs",
                newName: "DamageAssessmentBuildingId");

            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "DamagePDMAs",
                newName: "OtherTreeName");

            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "DamageIPs",
                newName: "DamageAssessmentBuildingId");

            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "DamageIPs",
                newName: "OtherTreeName");

            migrationBuilder.AddColumn<double>(
                name: "CropLandArea",
                table: "DamageVerifieds",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseCategory",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseNoOfRooms",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherCategory",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherNoOfRooms",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopCategory",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopNoOfRooms",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAnimals",
                table: "DamageVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTrees",
                table: "DamageVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAnimalName",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherAnimalNumber",
                table: "DamageVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OtherLandArea",
                table: "DamageVerifieds",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLandName",
                table: "DamageVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherTreeNumber",
                table: "DamageVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CropLandArea",
                table: "DamagePDMAs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseCategory",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseNoOfRooms",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherCategory",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherNoOfRooms",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopCategory",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopNoOfRooms",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAnimals",
                table: "DamagePDMAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTrees",
                table: "DamagePDMAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAnimalName",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherAnimalNumber",
                table: "DamagePDMAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OtherLandArea",
                table: "DamagePDMAs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLandName",
                table: "DamagePDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherTreeNumber",
                table: "DamagePDMAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CropLandArea",
                table: "DamageIPs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseCategory",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageHouseNoOfRooms",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherCategory",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageOtherNoOfRooms",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopCategory",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageShopNoOfRooms",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAnimals",
                table: "DamageIPs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTrees",
                table: "DamageIPs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAnimalName",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherAnimalNumber",
                table: "DamageIPs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OtherLandArea",
                table: "DamageIPs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLandName",
                table: "DamageIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherTreeNumber",
                table: "DamageIPs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKin",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinCNIC",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyDate",
                table: "BeneficiaryVerifieds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyTeamId",
                table: "BeneficiaryVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "BeneficiaryPDMAs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryIdentifiedFor",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKin",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinCNIC",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyDate",
                table: "BeneficiaryPDMAs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyTeamId",
                table: "BeneficiaryPDMAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKin",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinCNIC",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyDate",
                table: "BeneficiaryIPs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyTeamId",
                table: "BeneficiaryIPs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DamageAssessmentBuilding",
                columns: table => new
                {
                    DamageAssessmentBuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageAssessmentBuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageAssessmentBuilding", x => x.DamageAssessmentBuildingId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTeam",
                columns: table => new
                {
                    SurveyTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamLeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmyMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDMAMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectedByOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTeam", x => x.SurveyTeamId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DamageVerifieds_DamageAssessmentBuildingId",
                table: "DamageVerifieds",
                column: "DamageAssessmentBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagePDMAs_DamageAssessmentBuildingId",
                table: "DamagePDMAs",
                column: "DamageAssessmentBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageIPs_DamageAssessmentBuildingId",
                table: "DamageIPs",
                column: "DamageAssessmentBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamId",
                table: "BeneficiaryVerifieds",
                column: "SurveyTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryPDMAs_SurveyTeamId",
                table: "BeneficiaryPDMAs",
                column: "SurveyTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryIPs_SurveyTeamId",
                table: "BeneficiaryIPs",
                column: "SurveyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryIPs_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryIPs",
                column: "SurveyTeamId",
                principalTable: "SurveyTeam",
                principalColumn: "SurveyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryPDMAs_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryPDMAs",
                column: "SurveyTeamId",
                principalTable: "SurveyTeam",
                principalColumn: "SurveyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryVerifieds",
                column: "SurveyTeamId",
                principalTable: "SurveyTeam",
                principalColumn: "SurveyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageIPs_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamageIPs",
                column: "DamageAssessmentBuildingId",
                principalTable: "DamageAssessmentBuilding",
                principalColumn: "DamageAssessmentBuildingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DamagePDMAs_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamagePDMAs",
                column: "DamageAssessmentBuildingId",
                principalTable: "DamageAssessmentBuilding",
                principalColumn: "DamageAssessmentBuildingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DamageVerifieds_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamageVerifieds",
                column: "DamageAssessmentBuildingId",
                principalTable: "DamageAssessmentBuilding",
                principalColumn: "DamageAssessmentBuildingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryIPs_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryIPs");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryPDMAs_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeam_SurveyTeamId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_DamageIPs_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamageIPs");

            migrationBuilder.DropForeignKey(
                name: "FK_DamagePDMAs_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamagePDMAs");

            migrationBuilder.DropForeignKey(
                name: "FK_DamageVerifieds_DamageAssessmentBuilding_DamageAssessmentBuildingId",
                table: "DamageVerifieds");

            migrationBuilder.DropTable(
                name: "DamageAssessmentBuilding");

            migrationBuilder.DropTable(
                name: "SurveyTeam");

            migrationBuilder.DropIndex(
                name: "IX_DamageVerifieds_DamageAssessmentBuildingId",
                table: "DamageVerifieds");

            migrationBuilder.DropIndex(
                name: "IX_DamagePDMAs_DamageAssessmentBuildingId",
                table: "DamagePDMAs");

            migrationBuilder.DropIndex(
                name: "IX_DamageIPs_DamageAssessmentBuildingId",
                table: "DamageIPs");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryPDMAs_SurveyTeamId",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryIPs_SurveyTeamId",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "CropLandArea",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageHouseCategory",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageHouseNoOfRooms",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageOtherCategory",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageOtherNoOfRooms",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageShopCategory",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "DamageShopNoOfRooms",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "NumberOfAnimals",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "NumberOfTrees",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "OtherAnimalName",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "OtherAnimalNumber",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "OtherLandArea",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "OtherLandName",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "OtherTreeNumber",
                table: "DamageVerifieds");

            migrationBuilder.DropColumn(
                name: "CropLandArea",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageHouseCategory",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageHouseNoOfRooms",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageOtherCategory",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageOtherNoOfRooms",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageShopCategory",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "DamageShopNoOfRooms",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "NumberOfAnimals",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "NumberOfTrees",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "OtherAnimalName",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "OtherAnimalNumber",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "OtherLandArea",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "OtherLandName",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "OtherTreeNumber",
                table: "DamagePDMAs");

            migrationBuilder.DropColumn(
                name: "CropLandArea",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageHouseCategory",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageHouseNoOfRooms",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageOtherCategory",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageOtherNoOfRooms",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageShopCategory",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "DamageShopNoOfRooms",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "NumberOfAnimals",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "NumberOfTrees",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "OtherAnimalName",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "OtherAnimalNumber",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "OtherLandArea",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "OtherLandName",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "OtherTreeNumber",
                table: "DamageIPs");

            migrationBuilder.DropColumn(
                name: "NextOfKin",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "NextOfKinCNIC",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "SurveyDate",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "BeneficiaryIdentifiedFor",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "NextOfKin",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "NextOfKinCNIC",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "SurveyDate",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "NextOfKin",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "NextOfKinCNIC",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "SurveyDate",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryIPs");

            migrationBuilder.RenameColumn(
                name: "OtherTreeName",
                table: "DamageVerifieds",
                newName: "DamageType");

            migrationBuilder.RenameColumn(
                name: "DamageAssessmentBuildingId",
                table: "DamageVerifieds",
                newName: "Percentage");

            migrationBuilder.RenameColumn(
                name: "OtherTreeName",
                table: "DamagePDMAs",
                newName: "DamageType");

            migrationBuilder.RenameColumn(
                name: "DamageAssessmentBuildingId",
                table: "DamagePDMAs",
                newName: "Percentage");

            migrationBuilder.RenameColumn(
                name: "OtherTreeName",
                table: "DamageIPs",
                newName: "DamageType");

            migrationBuilder.RenameColumn(
                name: "DamageAssessmentBuildingId",
                table: "DamageIPs",
                newName: "Percentage");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "BeneficiaryPDMAs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
