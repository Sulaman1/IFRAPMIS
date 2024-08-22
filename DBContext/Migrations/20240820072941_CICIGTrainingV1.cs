using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class CICIGTrainingV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_Trainers_TrainerId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainerId",
                table: "CICIGTrainings");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "CICIGTrainings",
                newName: "TotalDays");

            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalClasses",
                table: "CICIGTrainings",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "TotalClasses",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "TrainerIds",
                table: "CICIGTrainings");

            migrationBuilder.RenameColumn(
                name: "TotalDays",
                table: "CICIGTrainings",
                newName: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainerId",
                table: "CICIGTrainings",
                column: "TrainerId",
                unique: true,
                filter: "[TrainerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_Trainers_TrainerId",
                table: "CICIGTrainings",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId");
        }
    }
}
