using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHead_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingHead",
                table: "TrainingHead");

            migrationBuilder.RenameTable(
                name: "TrainingHead",
                newName: "TrainingHeads");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHead_CICIGTrainingsId",
                table: "TrainingHeads",
                newName: "IX_TrainingHeads_CICIGTrainingsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingHeads",
                table: "TrainingHeads",
                column: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHeads_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHeads",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHeads_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHeads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingHeads",
                table: "TrainingHeads");

            migrationBuilder.RenameTable(
                name: "TrainingHeads",
                newName: "TrainingHead");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingHeads_CICIGTrainingsId",
                table: "TrainingHead",
                newName: "IX_TrainingHead_CICIGTrainingsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingHead",
                table: "TrainingHead",
                column: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHead_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHead",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
