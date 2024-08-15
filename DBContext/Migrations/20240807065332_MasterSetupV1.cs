using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provience",
                columns: table => new
                {
                    ProvienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provience", x => x.ProvienceId);
                }); 
            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Provience_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Provience",
                        principalColumn: "ProvienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Add the DivisionId column if it doesn't exist
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Create the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Divisions_DivisionId",
                table: "Districts",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts",
                column: "DivisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ProvienceId",
                table: "Divisions",
                column: "ProvienceId",
                unique: true);
                      
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Divisions_DivisionId",
                table: "Districts");

            // Remove the DivisionId column if it was added
            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Districts");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Provience");
        }
    }
}
