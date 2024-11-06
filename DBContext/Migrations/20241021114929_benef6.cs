using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class benef6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnHold",
                table: "BeneficiaryPDMAs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "BeneficiaryPDMAs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnHold",
                table: "BeneficiaryIPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "BeneficiaryIPs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnHold",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "BeneficiaryPDMAs");

            migrationBuilder.DropColumn(
                name: "IsOnHold",
                table: "BeneficiaryIPs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "BeneficiaryIPs");
        }
    }
}
