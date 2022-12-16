using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class Updategamees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_TeamId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_TeamId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_HomeTeam",
                table: "Game",
                column: "HomeTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_HomeTeam",
                table: "Game",
                column: "HomeTeam",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_HomeTeam",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_HomeTeam",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_TeamId",
                table: "Game",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_TeamId",
                table: "Game",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
