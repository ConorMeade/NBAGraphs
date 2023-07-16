// https://api-nba-v1.p.rapidapi.com/players/statistics


namespace NBAGraphs.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Game
    {
        public int id { get; set; }
    }

    public class GameLog
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public Game game { get; set; }
        public int points { get; set; }
        public string pos { get; set; }
        public string min { get; set; }
        public int fgm { get; set; }
        public int fga { get; set; }
        public string fgp { get; set; }
        public int ftm { get; set; }
        public int fta { get; set; }
        public string ftp { get; set; }
        public int tpm { get; set; }
        public int tpa { get; set; }
        public string tpp { get; set; }
        public int offReb { get; set; }
        public int defReb { get; set; }
        public int totReb { get; set; }
        public int assists { get; set; }
        public int pFouls { get; set; }
        public int steals { get; set; }
        public int turnovers { get; set; }
        public int blocks { get; set; }
        public string plusMinus { get; set; }
        public object comment { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class Season
    {
        public List<GameLog> GameLog { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string code { get; set; }
        public string logo { get; set; }
    }


}
