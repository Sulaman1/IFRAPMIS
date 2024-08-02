using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_CICIGs_CICIGId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_CICIGId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "CICIGId",
                table: "CICIGTrainings");

            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "CITrainingParticipations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.DropIndex(
                name: "IX_CITrainingParticipations_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.DropColumn(
                name: "CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.AddColumn<int>(
                name: "CICIGId",
                table: "CICIGTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_CICIGId",
                table: "CICIGTrainings",
                column: "CICIGId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_CICIGs_CICIGId",
                table: "CICIGTrainings",
                column: "CICIGId",
                principalTable: "CICIGs",
                principalColumn: "CICIGId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
