using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts",
                column: "DivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions",
                column: "ProvienceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts",
                column: "DivisionId",
                unique: true);
        }
    }
}
