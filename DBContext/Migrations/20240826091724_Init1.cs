using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHeads_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHeads");

            migrationBuilder.DropIndex(
                name: "IX_TrainingHeads_CICIGTrainingsId",
                table: "TrainingHeads");

            migrationBuilder.DropColumn(
                name: "CICIGTrainingsId",
                table: "TrainingHeads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "TrainingHeads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHeads_CICIGTrainingsId",
                table: "TrainingHeads",
                column: "CICIGTrainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHeads_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHeads",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId");
        }
    }
}
