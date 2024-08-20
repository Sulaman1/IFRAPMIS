using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Provience_ProvienceId",
                table: "Divisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provience",
                table: "Provience");

            migrationBuilder.RenameTable(
                name: "Provience",
                newName: "Proviences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proviences",
                table: "Proviences",
                column: "ProvienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Proviences_ProvienceId",
                table: "Divisions",
                column: "ProvienceId",
                principalTable: "Proviences",
                principalColumn: "ProvienceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Proviences_ProvienceId",
                table: "Divisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proviences",
                table: "Proviences");

            migrationBuilder.RenameTable(
                name: "Proviences",
                newName: "Provience");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provience",
                table: "Provience",
                column: "ProvienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Provience_ProvienceId",
                table: "Divisions",
                column: "ProvienceId",
                principalTable: "Provience",
                principalColumn: "ProvienceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
