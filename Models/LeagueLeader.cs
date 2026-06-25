namespace NBAGraphs.Models;

public class LeagueLeader
{
    public int PlayerId { get; set; }
    public int Rank { get; set; }
    public string Player { get; set; } = "";
    public int TeamId { get; set; }
    public string Team { get; set; } = "";
    public int GamesPlayed { get; set; }
    public float Minutes { get; set; }
    public float Points { get; set; }
    public float Assists { get; set; }
    public float Rebounds { get; set; }
    public float Steals { get; set; }
    public float Blocks { get; set; }
    public float FieldGoalPct { get; set; }
    public float ThreePointPct { get; set; }
    public float FreeThrowPct { get; set; }
    public float Efficiency { get; set; }
}
