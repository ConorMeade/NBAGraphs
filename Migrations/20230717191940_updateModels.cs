using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAGraphs.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<string>(type: "text", nullable: false),
                    fname = table.Column<string>(type: "text", nullable: true),
                    lname = table.Column<string>(type: "text", nullable: true),
                    points_per_game = table.Column<float>(type: "real", nullable: false),
                    assists_per_game = table.Column<float>(type: "real", nullable: false),
                    rebounds_per_game = table.Column<float>(type: "real", nullable: false),
                    games_played = table.Column<int>(type: "integer", nullable: false),
                    total_points = table.Column<int>(type: "integer", nullable: false),
                    rapid_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    team_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    primary_color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.team_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
