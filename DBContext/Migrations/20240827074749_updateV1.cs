using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class updateV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs",
                column: "PhaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");
        }
    }
}
