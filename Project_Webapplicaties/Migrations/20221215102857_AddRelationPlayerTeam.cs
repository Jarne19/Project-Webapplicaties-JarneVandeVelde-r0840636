using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class AddRelationPlayerTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PloegId",
                table: "Player",
                column: "PloegId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_PloegId",
                table: "Player",
                column: "PloegId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_PloegId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_PloegId",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
