using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class fixPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PastDetails",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Player",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Player");

            migrationBuilder.AddColumn<string>(
                name: "PastDetails",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
