//using NBAGraphs.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Swashbuckle.Models;

/// <summary>
/// Stock data
/// </summary>
public class PlayerModel
{
    [Required] 
    public string? player_id { get; set; }

    public string? fname { get; set; }

    public string? lname { get; set; }

    public float points_per_game { get; set; }

    public int games_played { get; set; }

    public int total_points { get; set; }

    public Team? team_id { get; set; }
}
