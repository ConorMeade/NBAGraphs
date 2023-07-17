//using NBAGraphs.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBAGraphs.Models;

public class Player
{
    [Required, Key] 
    public string? player_id { get; set; }

    public string? fname { get; set; }

    public string? lname { get; set; }

    public float points_per_game { get; set; }

    public float assists_per_game { get; set; }

    public float rebounds_per_game { get; set; }

    public int games_played { get; set; }

    public int total_points { get; set; }

    public int rapid_id { get; set; }

    [ForeignKey("Team")]
    public int player_team { get; set; }
}
