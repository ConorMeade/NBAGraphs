// https://api-nba-v1.p.rapidapi.com/players/statistics


namespace NBAGraphs.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class GameLog
    {
        public string? player_id { get; set; }
        public string? team_id { get; set; }
        
        public string? fname { get; set; }

        public string? lname { get; set; }
        public string? game_id { get; set; }
        public int points { get; set; }
        public string? pos { get; set; }
        public string? min { get; set; }
        public int fgm { get; set; }
        public int fga { get; set; }
        public string? fgp { get; set; }
        public int ftm { get; set; }
        public int fta { get; set; }
        public string? ftp { get; set; }
        public int tpm { get; set; }
        public int tpa { get; set; }
        public string? tpp { get; set; }
        public int offReb { get; set; }
        public int defReb { get; set; }
        public int totReb { get; set; }
        public int assists { get; set; }
        public int pFouls { get; set; }
        public int steals { get; set; }
        public int turnovers { get; set; }
        public int blocks { get; set; }
        public string? plusMinus { get; set; }
        public string? comment { get; set; }
    }

    public class Season
    {
        public List<GameLog>? GameLog { get; set; }
    }
}
