using System.ComponentModel.DataAnnotations;
namespace NBAGraphs.Models;

public class Team
{
    [Required, Key]
    public string? team_id { get; set; }

    public string? name { get; set; }

    public string? city { get; set; }

    public string? logo_url { get; set; }

    public string? primary_color { get; set; }
}
