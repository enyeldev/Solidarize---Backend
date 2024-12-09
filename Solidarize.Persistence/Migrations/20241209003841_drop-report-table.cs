using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidarize.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dropreporttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenerateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDonated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDonors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }
    }
}
