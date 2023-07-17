using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAGraphs.Migrations
{
    /// <inheritdoc />
    public partial class updatePlayerModelFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_teams_fk_team_idteam_id",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_fk_team_idteam_id",
                table: "players");

            migrationBuilder.DropColumn(
                name: "fk_team_idteam_id",
                table: "players");

            migrationBuilder.AddColumn<int>(
                name: "player_team",
                table: "players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rapid_id",
                table: "players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "player_team",
                table: "players");

            migrationBuilder.DropColumn(
                name: "rapid_id",
                table: "players");

            migrationBuilder.AddColumn<string>(
                name: "fk_team_idteam_id",
                table: "players",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_fk_team_idteam_id",
                table: "players",
                column: "fk_team_idteam_id");

            migrationBuilder.AddForeignKey(
                name: "FK_players_teams_fk_team_idteam_id",
                table: "players",
                column: "fk_team_idteam_id",
                principalTable: "teams",
                principalColumn: "team_id");
        }
    }
}
