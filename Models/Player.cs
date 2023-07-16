//using NBAGraphs.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NBAGraphs.Models;

public class Player
{
    [Required, Key] 
    public string? player_id { get; set; }

    public string? fname { get; set; }

    public string? lname { get; set; }

    public float points_per_game { get; set; }

    public int games_played { get; set; }

    public int total_points { get; set; }

    [Key]
    public Team? fk_team_id { get; set; }
}
