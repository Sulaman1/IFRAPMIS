using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class componentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDSummary",
                columns: table => new
                {
                    CommunityInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TehsilName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnionCouncilName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDForm = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    SubmittedForReview = table.Column<int>(type: "int", nullable: false),
                    SubmittedForApproval = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<int>(type: "int", nullable: false),
                    UnionCouncilId = table.Column<int>(type: "int", nullable: false),
                    CommunityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDSummary", x => x.CommunityInstitutionId);
                    table.ForeignKey(
                        name: "FK_CDSummary_CommunityTypes_CommunityTypeId",
                        column: x => x.CommunityTypeId,
                        principalTable: "CommunityTypes",
                        principalColumn: "CommunityTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CDSummary_UnionCouncils_UnionCouncilId",
                        column: x => x.UnionCouncilId,
                        principalTable: "UnionCouncils",
                        principalColumn: "UnionCouncilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SPToolAnalysis",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitute = table.Column<double>(type: "float", nullable: false),
                    Longitute = table.Column<double>(type: "float", nullable: false),
                    ControlLebel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPToolAnalysis", x => x.ToolId);
                });

            migrationBuilder.CreateTable(
                name: "ToolSummary3",
                columns: table => new
                {
                    RowNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Counter = table.Column<int>(type: "int", nullable: true),
                    MD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitute = table.Column<double>(type: "float", nullable: true),
                    Longitute = table.Column<double>(type: "float", nullable: true),
                    ControlLebel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOffline = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolSummary3", x => x.RowNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDSummary_CommunityTypeId",
                table: "CDSummary",
                column: "CommunityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CDSummary_UnionCouncilId",
                table: "CDSummary",
                column: "UnionCouncilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDSummary");

            migrationBuilder.DropTable(
                name: "SPToolAnalysis");

            migrationBuilder.DropTable(
                name: "ToolSummary3");
        }
    }
}
