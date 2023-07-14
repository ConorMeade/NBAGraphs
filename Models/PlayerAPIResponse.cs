//'https://api-nba-v1.p.rapidapi.com/players',

namespace NBAGraphs.Models
{
    public class NBARapidAPIPlayerResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Birth
    {
        public string date { get; set; }
        public string country { get; set; }
    }

    public class Height
    {
        public string feets { get; set; }
        public string inches { get; set; }
        public string meters { get; set; }
    }

    public class Leagues
    {
        public Standard standard { get; set; }
    }

    public class Nba
    {
        public int start { get; set; }
        public int pro { get; set; }
    }

    public class Response
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Birth birth { get; set; }
        public Nba nba { get; set; }
        public Height height { get; set; }
        public Weight weight { get; set; }
        public string college { get; set; }
        public string affiliation { get; set; }
        public Leagues leagues { get; set; }
    }

    public class Root
    {
        public List<Response> response { get; set; }
    }

    public class Standard
    {
        public object jersey { get; set; }
        public bool active { get; set; }
        public string pos { get; set; }
    }

    public class Weight
    {
        public string pounds { get; set; }
        public string kilograms { get; set; }
    }


    }
}
