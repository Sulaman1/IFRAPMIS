using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class CICIGTrainingV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachement3",
                table: "CICIGs",
                newName: "VillageProfileAttachment");

            migrationBuilder.RenameColumn(
                name: "Attachement2",
                table: "CICIGs",
                newName: "TOPAttachment");

            migrationBuilder.RenameColumn(
                name: "Attachement1",
                table: "CICIGs",
                newName: "SubmittedForReviewBy");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommunityTypeId",
                table: "CICIGs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseHoldParticipated",
                table: "CICIGs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "CICIGs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "CICIGs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmittedForReview",
                table: "CICIGs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectedComments",
                table: "CICIGs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "CICIGs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedDate",
                table: "CICIGs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectionFormAttachment",
                table: "CICIGs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedForReviewDate",
                table: "CICIGs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommunityTypes",
                columns: table => new
                {
                    CommunityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTypes", x => x.CommunityTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_DistrictId",
                table: "Trainers",
                column: "DistrictId",
                unique: true,
                filter: "[DistrictId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CICIGs_CommunityTypeId",
                table: "CICIGs",
                column: "CommunityTypeId",
                unique: true,
                filter: "[CommunityTypeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CICIGs_CommunityTypes_CommunityTypeId",
                table: "CICIGs",
                column: "CommunityTypeId",
                principalTable: "CommunityTypes",
                principalColumn: "CommunityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Districts_DistrictId",
                table: "Trainers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CICIGs_CommunityTypes_CommunityTypeId",
                table: "CICIGs");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Districts_DistrictId",
                table: "Trainers");

            migrationBuilder.DropTable(
                name: "CommunityTypes");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_DistrictId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_CICIGs_CommunityTypeId",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CommunityTypeId",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "HouseHoldParticipated",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "IsSubmittedForReview",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "RejectedComments",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "SelectionFormAttachment",
                table: "CICIGs");

            migrationBuilder.DropColumn(
                name: "SubmittedForReviewDate",
                table: "CICIGs");

            migrationBuilder.RenameColumn(
                name: "VillageProfileAttachment",
                table: "CICIGs",
                newName: "Attachement3");

            migrationBuilder.RenameColumn(
                name: "TOPAttachment",
                table: "CICIGs",
                newName: "Attachement2");

            migrationBuilder.RenameColumn(
                name: "SubmittedForReviewBy",
                table: "CICIGs",
                newName: "Attachement1");
        }
    }
}
