using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId",
                unique: true,
                filter: "[TrainingTitleId] IS NOT NULL");
        }
    }
}
