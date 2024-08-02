using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.AddForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations");

            migrationBuilder.AddForeignKey(
                name: "FK_CITrainingParticipations_CICIGTrainings_CICIGTrainingsId",
                table: "CITrainingParticipations",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId");
        }
    }
}
