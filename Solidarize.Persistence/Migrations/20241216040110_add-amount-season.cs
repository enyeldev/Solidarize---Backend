using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidarize.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addamountseason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Season",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Season");
        }
    }
}
