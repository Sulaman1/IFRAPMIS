using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV7 : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "TrainingHeadName",
                table: "TrainingHeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingHeadCode",
                table: "TrainingHeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TrainingHeadId",
                table: "CICIGTrainings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings",
                column: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_TrainingHeads_TrainingHeadId",
                table: "CICIGTrainings",
                column: "TrainingHeadId",
                principalTable: "TrainingHeads",
                principalColumn: "TrainingHeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_TrainingHeads_TrainingHeadId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainingHeadId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "TrainingHeadCode",
                table: "TrainingHeads");

            migrationBuilder.DropColumn(
                name: "TrainingHeadId",
                table: "CICIGTrainings");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingHeadName",
                table: "TrainingHeads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CICIGTrainingsId",
                table: "TrainingHeads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHeads_CICIGTrainingsId",
                table: "TrainingHeads",
                column: "CICIGTrainingsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHeads_CICIGTrainings_CICIGTrainingsId",
                table: "TrainingHeads",
                column: "CICIGTrainingsId",
                principalTable: "CICIGTrainings",
                principalColumn: "CICIGTrainingsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
