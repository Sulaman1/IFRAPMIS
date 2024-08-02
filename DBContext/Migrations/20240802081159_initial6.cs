using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingHeadName",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingTitleName",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tehsil",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCouncil",
                table: "BeneficiaryVerifieds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tehsil",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCouncil",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tehsil",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCouncil",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingHead",
                columns: table => new
                {
                    TrainingHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingHeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingHead", x => x.TrainingHeadId);
                    table.ForeignKey(
                        name: "FK_TrainingHead_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTitle",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTitle", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_TrainingTitle_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHead_CICIGTrainingsId",
                table: "TrainingHead",
                column: "CICIGTrainingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTitle_CICIGTrainingsId",
                table: "TrainingTitle",
                column: "CICIGTrainingsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingHead");

            migrationBuilder.DropTable(
                name: "TrainingTitle");

            migrationBuilder.DropColumn(
                name: "TrainingHeadName",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "TrainingTitleName",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "District",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "Tehsil",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "UnionCouncil",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "District",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "Tehsil",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "UnionCouncil",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "District",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "Tehsil",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "UnionCouncil",
                table: "BeneficiaryIPs");
        }
    }
}
