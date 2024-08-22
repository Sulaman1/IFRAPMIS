using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class MasterSetupV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisabilityType",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "DisabilityType",
                table: "BeneficiaryIPs");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "BeneficiaryPDMAs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefugee",
                table: "BeneficiaryPDMAs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "BeneficiaryPDMAs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "BeneficiaryIPs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefugee",
                table: "BeneficiaryIPs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "BeneficiaryIPs",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "IsRefugee",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "IsRefugee",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "BeneficiaryIPs");

            migrationBuilder.AddColumn<string>(
                name: "DisabilityType",
                table: "BeneficiaryPDMAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityType",
                table: "BeneficiaryIPs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
