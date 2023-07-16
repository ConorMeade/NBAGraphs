﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAGraphs.Migrations
{
    /// <inheritdoc />
    public partial class InitialPlayerCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    team_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    points_per_game = table.Column<float>(type: "real", nullable: false),
                    games_played = table.Column<int>(type: "int", nullable: false),
                    total_points = table.Column<int>(type: "int", nullable: false),
                    fk_team_idteam_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_players_teams_fk_team_idteam_id",
                        column: x => x.fk_team_idteam_id,
                        principalTable: "teams",
                        principalColumn: "team_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_fk_team_idteam_id",
                table: "players",
                column: "fk_team_idteam_id");
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
