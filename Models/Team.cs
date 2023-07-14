using System.ComponentModel.DataAnnotations;
namespace Swashbuckle.Models;


public class Team
{
    [Required]
    public string? team_id { get; set; }

    public string? name { get; set; }

    public string? city { get; set; }

    public string? logo_url { get; set; }
}
