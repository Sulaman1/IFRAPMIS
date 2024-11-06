using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class benef3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "SurveyTeam");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryVerifieds",
                newName: "SurveyTeamPDMAId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamId",
                table: "BeneficiaryVerifieds",
                newName: "IX_BeneficiaryVerifieds_SurveyTeamPDMAId");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryPDMAs",
                newName: "SurveyTeamPDMAId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryPDMAs_SurveyTeamId",
                table: "BeneficiaryPDMAs",
                newName: "IX_BeneficiaryPDMAs_SurveyTeamPDMAId");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamId",
                table: "BeneficiaryIPs",
                newName: "SurveyTeamIPId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryIPs_SurveyTeamId",
                table: "BeneficiaryIPs",
                newName: "IX_BeneficiaryIPs_SurveyTeamIPId");

            migrationBuilder.AddColumn<int>(
                name: "SurveyTeamIPId",
                table: "BeneficiaryVerifieds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SurveyTeamIP",
                columns: table => new
                {
                    SurveyTeamIPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamLeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectedByOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTeamIP", x => x.SurveyTeamIPId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTeamPDMA",
                columns: table => new
                {
                    SurveyTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamLeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmyMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDMAMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTeamPDMA", x => x.SurveyTeamId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamIPId",
                table: "BeneficiaryVerifieds",
                column: "SurveyTeamIPId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryIPs_SurveyTeamIP_SurveyTeamIPId",
                table: "BeneficiaryIPs",
                column: "SurveyTeamIPId",
                principalTable: "SurveyTeamIP",
                principalColumn: "SurveyTeamIPId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryPDMAs_SurveyTeamPDMA_SurveyTeamPDMAId",
                table: "BeneficiaryPDMAs",
                column: "SurveyTeamPDMAId",
                principalTable: "SurveyTeamPDMA",
                principalColumn: "SurveyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeamIP_SurveyTeamIPId",
                table: "BeneficiaryVerifieds",
                column: "SurveyTeamIPId",
                principalTable: "SurveyTeamIP",
                principalColumn: "SurveyTeamIPId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeamPDMA_SurveyTeamPDMAId",
                table: "BeneficiaryVerifieds",
                column: "SurveyTeamPDMAId",
                principalTable: "SurveyTeamPDMA",
                principalColumn: "SurveyTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryIPs_SurveyTeamIP_SurveyTeamIPId",
                table: "BeneficiaryIPs");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryPDMAs_SurveyTeamPDMA_SurveyTeamPDMAId",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeamIP_SurveyTeamIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_SurveyTeamPDMA_SurveyTeamPDMAId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropTable(
                name: "SurveyTeamIP");

            migrationBuilder.DropTable(
                name: "SurveyTeamPDMA");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "SurveyTeamIPId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamPDMAId",
                table: "BeneficiaryVerifieds",
                newName: "SurveyTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryVerifieds_SurveyTeamPDMAId",
                table: "BeneficiaryVerifieds",
                newName: "IX_BeneficiaryVerifieds_SurveyTeamId");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamPDMAId",
                table: "BeneficiaryPDMAs",
                newName: "SurveyTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryPDMAs_SurveyTeamPDMAId",
                table: "BeneficiaryPDMAs",
                newName: "IX_BeneficiaryPDMAs_SurveyTeamId");

            migrationBuilder.RenameColumn(
                name: "SurveyTeamIPId",
                table: "BeneficiaryIPs",
                newName: "SurveyTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_BeneficiaryIPs_SurveyTeamIPId",
                table: "BeneficiaryIPs",
                newName: "IX_BeneficiaryIPs_SurveyTeamId");

            migrationBuilder.CreateTable(
                name: "SurveyTeam",
                columns: table => new
                {
                    SurveyTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectedByOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member3Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDMAMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLeadName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTeam", x => x.SurveyTeamId);
                });

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
        }
    }
}
