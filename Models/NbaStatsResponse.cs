namespace NBAGraphs.Models;

public class NbaStatsResponse
{
    public string? resource { get; set; }
    public List<ResultSet>? resultSets { get; set; }
}

public class ResultSet
{
    public string? name { get; set; }
    public List<string>? headers { get; set; }
    public List<List<object>>? rowSet { get; set; }
}
