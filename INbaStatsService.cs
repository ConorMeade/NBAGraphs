using NBAGraphs.Models;

namespace NBAGraphs;

public interface INbaStatsService
{
    Task<List<GameLog>> GetPlayerGameLog(int playerId, string season);
    Task<Player> GetPlayerSeasonAverages(int playerId, string season);
    Task<List<LeagueLeader>> GetLeagueLeaders(string season, string statCategory = "PTS");
}
