using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_Villages_VillageId",
                table: "CICIGTrainings");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_Villages_VillageId",
                table: "CICIGTrainings",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "VillageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_Villages_VillageId",
                table: "CICIGTrainings");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_Villages_VillageId",
                table: "CICIGTrainings",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "VillageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
