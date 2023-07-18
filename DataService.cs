using NBAGraphs.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockTracker
{
    public class DataService : IDataService
    {
        static HttpClient client = new HttpClient();
        ///<summary>
        /// Use Rapid API nba endpoint to get player data and game log
        ///</summary>
        /// <param name="id">Rapid api id lookup for player</param>
        /// <param name="teamId">Rapid api id lookup for team, needed to execute request</param>
        ///

        // BE VERY CAREFUL, only limited to 100 reqs/day
        public async Task<List<GameLog>> GetPlayerGameLog(string id, string teamId)
        {
            List<GameLog>? gameLog = null;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-nba-v1.p.rapidapi.com/players/statistics?id=236&season=2020"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { "X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com" },
                    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }

            return gameLog;
        }

        public Player ParseGameLog(string jsonData)
        {
            Player playerInfo = new Player();
            Guid guid = Guid.NewGuid();
            string myuuidAsString = guid.ToString();

            string json = "";
            using (StreamReader r = new StreamReader("/PlayerJSONs/buddy_hield_game_log_20.json"))
            {
                json = r.ReadToEnd();
            }

            JObject items = JObject.Parse(json);

            var valueArray = (JArray)items["response"];
            int gamesPlayed = valueArray.Count;
            float ppg = 0.0f;
            float apg = 0.0f;
            float rpg = 0.0f;
            int total_points = 0;
            int total_assists = 0;
            int total_rebounds = 0;
            int team_id = 26;
            int rapidId = 0;
            string fname = "";
            string lname = "";
            foreach (JObject v in valueArray)
            {
                foreach (var property in v.Properties())
                {
                    if(property.Name == "player")
                    {
                        rapidId = (int)property["player"]["id"];
                        fname = (string)property["player"]["firstname"];
                        lname = (string)property["player"]["lastname"];
                    }

                    total_points += (int)property["points"];
                    total_assists += (int)property["assists"];
                    total_rebounds += (int)property["totReb"];
                }
            }

            playerInfo.player_id = myuuidAsString;
            playerInfo.fname = fname;
            playerInfo.lname = lname;
            playerInfo.points_per_game = (float)total_points / (float)gamesPlayed;
            playerInfo.assists_per_game = (float)total_assists / (float)gamesPlayed;
            playerInfo.rebounds_per_game = (float)total_rebounds / (float)gamesPlayed;
            playerInfo.games_played = gamesPlayed;
            playerInfo.total_points = total_points;
            playerInfo.rapid_id = rapidId;
            playerInfo.team_id = "26";

            return playerInfo;
        }

    }

}



