using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class fixsponsorimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SponsorImage",
                table: "Sponsor");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sponsor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sponsor");

            migrationBuilder.AddColumn<string>(
                name: "SponsorImage",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
