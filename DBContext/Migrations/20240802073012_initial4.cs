using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryVerifieds_CICIGs_CICIGId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryVerifieds_CICIGId",
                table: "BeneficiaryVerifieds");

            migrationBuilder.DropColumn(
                name: "CICIGId",
                table: "BeneficiaryVerifieds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CICIGId",
                table: "BeneficiaryVerifieds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVerifieds_CICIGId",
                table: "BeneficiaryVerifieds",
                column: "CICIGId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryVerifieds_CICIGs_CICIGId",
                table: "BeneficiaryVerifieds",
                column: "CICIGId",
                principalTable: "CICIGs",
                principalColumn: "CICIGId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
