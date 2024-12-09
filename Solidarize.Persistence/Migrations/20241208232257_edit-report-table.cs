using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidarize.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editreporttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Report");

            migrationBuilder.AddColumn<string>(
                name: "ReportName",
                table: "Report",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalDonors",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportName",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "TotalDonors",
                table: "Report");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Report",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
