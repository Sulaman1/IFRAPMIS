using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class addedsometablesanddbadustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_TrainingTitle_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Teshsils_Districts_DistrictId",
                table: "Teshsils");

            migrationBuilder.DropForeignKey(
                name: "FK_UnionCouncils_Teshsils_TehsilId",
                table: "UnionCouncils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingTitle",
                table: "TrainingTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teshsils",
                table: "Teshsils");

            migrationBuilder.RenameTable(
                name: "TrainingTitle",
                newName: "TrainingTitles");

            migrationBuilder.RenameTable(
                name: "Teshsils",
                newName: "Tehsils");

            migrationBuilder.RenameColumn(
                name: "Attachment3",
                table: "CICIGTrainings",
                newName: "SessionPlanAttachment");

            migrationBuilder.RenameColumn(
                name: "Attachment2",
                table: "CICIGTrainings",
                newName: "ReportAttachment");

            migrationBuilder.RenameColumn(
                name: "Attachment1",
                table: "CICIGTrainings",
                newName: "PictureAttachment4");

            migrationBuilder.RenameIndex(
                name: "IX_Teshsils_DistrictId",
                table: "Tehsils",
                newName: "IX_Tehsils_DistrictId");

            migrationBuilder.AddColumn<string>(
                name: "AttendanceAttachment",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "CICIGTrainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureAttachment1",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureAttachment2",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureAttachment3",
                table: "CICIGTrainings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "CICIGTrainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "CICIGs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingHeadId",
                table: "TrainingTitles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingTitleCode",
                table: "TrainingTitles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingTitles",
                table: "TrainingTitles",
                column: "TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tehsils",
                table: "Tehsils",
                column: "TehsilId");

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    PhaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.PhaseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGTrainings_TrainerId",
                table: "CICIGTrainings",
                column: "TrainerId",
                unique: true,
                filter: "[TrainerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs",
                column: "PhaseId",
                unique: true,
                filter: "[PhaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTitles_TrainingHeadId",
                table: "TrainingTitles",
                column: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGs_Phases_PhaseId",
                table: "CICIGs",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_Phases_PhaseId",
                table: "CICIGTrainings",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_Trainers_TrainerId",
                table: "CICIGTrainings",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_TrainingTitles_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId",
                principalTable: "TrainingTitles",
                principalColumn: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tehsils_Districts_DistrictId",
                table: "Tehsils",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingTitles_TrainingHeads_TrainingHeadId",
                table: "TrainingTitles",
                column: "TrainingHeadId",
                principalTable: "TrainingHeads",
                principalColumn: "TrainingHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnionCouncils_Tehsils_TehsilId",
                table: "UnionCouncils",
                column: "TehsilId",
                principalTable: "Tehsils",
                principalColumn: "TehsilId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGs_Phases_PhaseId",
                table: "CICIGs");

            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_Phases_PhaseId",
                table: "CICIGTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_Trainers_TrainerId",
                table: "CICIGTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_CICIGTrainings_TrainingTitles_TrainingTitleId",
                table: "CICIGTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tehsils_Districts_DistrictId",
                table: "Tehsils");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingTitles_TrainingHeads_TrainingHeadId",
                table: "TrainingTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_UnionCouncils_Tehsils_TehsilId",
                table: "UnionCouncils");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_PhaseId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGTrainings_TrainerId",
                table: "CICIGTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CICIGs_PhaseId",
                table: "CICIGs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingTitles",
                table: "TrainingTitles");

            migrationBuilder.DropIndex(
                name: "IX_TrainingTitles_TrainingHeadId",
                table: "TrainingTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tehsils",
                table: "Tehsils");

            migrationBuilder.DropColumn(
                name: "AttendanceAttachment",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "PictureAttachment1",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "PictureAttachment2",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "PictureAttachment3",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "CICIGTrainings");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "TrainingHeadId",
                table: "TrainingTitles");

            migrationBuilder.DropColumn(
                name: "TrainingTitleCode",
                table: "TrainingTitles");

            migrationBuilder.RenameTable(
                name: "TrainingTitles",
                newName: "TrainingTitle");

            migrationBuilder.RenameTable(
                name: "Tehsils",
                newName: "Teshsils");

            migrationBuilder.RenameColumn(
                name: "SessionPlanAttachment",
                table: "CICIGTrainings",
                newName: "Attachment3");

            migrationBuilder.RenameColumn(
                name: "ReportAttachment",
                table: "CICIGTrainings",
                newName: "Attachment2");

            migrationBuilder.RenameColumn(
                name: "PictureAttachment4",
                table: "CICIGTrainings",
                newName: "Attachment1");

            migrationBuilder.RenameIndex(
                name: "IX_Tehsils_DistrictId",
                table: "Teshsils",
                newName: "IX_Teshsils_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingTitle",
                table: "TrainingTitle",
                column: "TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teshsils",
                table: "Teshsils",
                column: "TehsilId");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGTrainings_TrainingTitle_TrainingTitleId",
                table: "CICIGTrainings",
                column: "TrainingTitleId",
                principalTable: "TrainingTitle",
                principalColumn: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teshsils_Districts_DistrictId",
                table: "Teshsils",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnionCouncils_Teshsils_TehsilId",
                table: "UnionCouncils",
                column: "TehsilId",
                principalTable: "Teshsils",
                principalColumn: "TehsilId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
