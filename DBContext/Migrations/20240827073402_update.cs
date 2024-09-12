using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CIIrainingParticipationId",
                table: "CITrainingParticipations",
                newName: "CITrainingParticipationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CITrainingParticipationId",
                table: "CITrainingParticipations",
                newName: "CIIrainingParticipationId");
        }
    }
}
