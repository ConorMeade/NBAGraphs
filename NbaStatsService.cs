using NBAGraphs.Models;
using Newtonsoft.Json;

namespace NBAGraphs;

public class NbaStatsService : INbaStatsService
{
    private readonly HttpClient _client;

    public NbaStatsService(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://stats.nba.com/stats/");
        _client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
        _client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        _client.DefaultRequestHeaders.Add("Referer", "https://stats.nba.com/");
        _client.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
        _client.DefaultRequestHeaders.Add("Origin", "https://stats.nba.com");
        _client.DefaultRequestHeaders.Add("x-nba-stats-origin", "stats");
        _client.DefaultRequestHeaders.Add("x-nba-stats-token", "true");
    }

    public async Task<List<GameLog>> GetPlayerGameLog(int playerId, string season)
    {
        var url = $"playergamelog?PlayerID={playerId}&Season={season}&SeasonType=Regular+Season";
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var statsResponse = JsonConvert.DeserializeObject<NbaStatsResponse>(json);

        var resultSet = statsResponse?.resultSets?.FirstOrDefault();
        if (resultSet?.headers == null || resultSet.rowSet == null)
            return new List<GameLog>();

        var headers = resultSet.headers;
        var gameLogs = new List<GameLog>();

        foreach (var row in resultSet.rowSet)
        {
            gameLogs.Add(new GameLog
            {
                player_id = GetValue<string>(row, headers, "Player_ID"),
                game_id = GetValue<string>(row, headers, "Game_ID"),
                points = GetIntValue(row, headers, "PTS"),
                assists = GetIntValue(row, headers, "AST"),
                totReb = GetIntValue(row, headers, "REB"),
                offReb = GetIntValue(row, headers, "OREB"),
                defReb = GetIntValue(row, headers, "DREB"),
                steals = GetIntValue(row, headers, "STL"),
                blocks = GetIntValue(row, headers, "BLK"),
                turnovers = GetIntValue(row, headers, "TOV"),
                pFouls = GetIntValue(row, headers, "PF"),
                fgm = GetIntValue(row, headers, "FGM"),
                fga = GetIntValue(row, headers, "FGA"),
                fgp = GetValue<string>(row, headers, "FG_PCT"),
                ftm = GetIntValue(row, headers, "FTM"),
                fta = GetIntValue(row, headers, "FTA"),
                ftp = GetValue<string>(row, headers, "FT_PCT"),
                tpm = GetIntValue(row, headers, "FG3M"),
                tpa = GetIntValue(row, headers, "FG3A"),
                tpp = GetValue<string>(row, headers, "FG3_PCT"),
                min = GetValue<string>(row, headers, "MIN"),
                plusMinus = GetValue<string>(row, headers, "PLUS_MINUS"),
            });
        }

        return gameLogs;
    }

    public async Task<Player> GetPlayerSeasonAverages(int playerId, string season)
    {
        var gameLogs = await GetPlayerGameLog(playerId, season);

        if (gameLogs.Count == 0)
            return new Player();

        int totalPoints = gameLogs.Sum(g => g.points);
        int totalAssists = gameLogs.Sum(g => g.assists);
        int totalRebounds = gameLogs.Sum(g => g.totReb);
        int gamesPlayed = gameLogs.Count;

        return new Player
        {
            player_id = Guid.NewGuid().ToString(),
            points_per_game = (float)totalPoints / gamesPlayed,
            assists_per_game = (float)totalAssists / gamesPlayed,
            rebounds_per_game = (float)totalRebounds / gamesPlayed,
            games_played = gamesPlayed,
            total_points = totalPoints,
            rapid_id = playerId,
        };
    }

    public async Task<List<LeagueLeader>> GetLeagueLeaders(string season, string statCategory = "PTS")
    {
        var url = $"leagueleaders?LeagueID=00&PerMode=PerGame&Scope=S&Season={season}&SeasonType=Regular+Season&StatCategory={statCategory}";
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var statsResponse = JsonConvert.DeserializeObject<NbaStatsResponse>(json);

        var resultSet = statsResponse?.resultSets?.FirstOrDefault();
        if (resultSet?.headers == null || resultSet.rowSet == null)
            return new List<LeagueLeader>();

        var headers = resultSet.headers;
        var leaders = new List<LeagueLeader>();

        foreach (var row in resultSet.rowSet)
        {
            leaders.Add(new LeagueLeader
            {
                PlayerId = GetIntValue(row, headers, "PLAYER_ID"),
                Rank = GetIntValue(row, headers, "RANK"),
                Player = GetValue<string>(row, headers, "PLAYER") ?? "",
                TeamId = GetIntValue(row, headers, "TEAM_ID"),
                Team = GetValue<string>(row, headers, "TEAM") ?? "",
                GamesPlayed = GetIntValue(row, headers, "GP"),
                Minutes = GetFloatValue(row, headers, "MIN"),
                Points = GetFloatValue(row, headers, "PTS"),
                Assists = GetFloatValue(row, headers, "AST"),
                Rebounds = GetFloatValue(row, headers, "REB"),
                Steals = GetFloatValue(row, headers, "STL"),
                Blocks = GetFloatValue(row, headers, "BLK"),
                FieldGoalPct = GetFloatValue(row, headers, "FG_PCT"),
                ThreePointPct = GetFloatValue(row, headers, "FG3_PCT"),
                FreeThrowPct = GetFloatValue(row, headers, "FT_PCT"),
                Efficiency = GetFloatValue(row, headers, "EFF"),
            });
        }

        return leaders;
    }

    private T? GetValue<T>(List<object> row, List<string> headers, string headerName)
    {
        var index = headers.IndexOf(headerName);
        if (index < 0 || index >= row.Count || row[index] == null)
            return default;

        var stringValue = row[index].ToString();
        if (string.IsNullOrEmpty(stringValue))
            return default;

        var convertedValue = Convert.ChangeType(stringValue, typeof(T));
        return convertedValue is T typedValue ? typedValue : default;
    }

    private int GetIntValue(List<object> row, List<string> headers, string headerName)
    {
        var index = headers.IndexOf(headerName);
        if (index < 0 || index >= row.Count || row[index] == null)
            return 0;

        return Convert.ToInt32(Convert.ToDouble(row[index].ToString()));
    }

    private float GetFloatValue(List<object> row, List<string> headers, string headerName)
    {
        var index = headers.IndexOf(headerName);
        if (index < 0 || index >= row.Count || row[index] == null)
            return 0f;

        return (float)Convert.ToDouble(row[index].ToString());
    }
}
