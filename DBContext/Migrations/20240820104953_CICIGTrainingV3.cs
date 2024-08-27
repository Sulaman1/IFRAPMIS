using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class CICIGTrainingV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_CICIGTrainings_CICIGTrainingsId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_CICIGTrainingsId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CICIGTrainingsId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainerIds",
                table: "CICIGTrainings");

            migrationBuilder.CreateTable(
                name: "CICIGTrainingTrainer",
                columns: table => new
                {
                    CICIGTrainingsId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICIGTrainingTrainer", x => new { x.CICIGTrainingsId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_CICIGTrainingTrainer_CICIGTrainings_CICIGTrainingsId",
                        column: x => x.CICIGTrainingsId,
                        principalTable: "CICIGTrainings",
                        principalColumn: "CICIGTrainingsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CICIGTrainingTrainer_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainingTrainer_TrainerId",
                table: "CICIGTrainingTrainer",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CICIGTrainingTrainer");

            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainerIds",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CICIGTrainingsId",
                table: "Trainers",
                column: "CICIGTrainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_CICIGTrainings_CICIGTrainingsId",
                table: "Trainers",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId");
        }
    }
}
