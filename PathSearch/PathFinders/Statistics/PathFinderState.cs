using PathSearch.MapGenerator;

namespace PathSearch.PathFinders.Statistics;

public record PathFinderState
{
    public string? Name { get; set; }
    public string[,]? Map { get; init; }
    public List<Point>? Path { get; init; }
    public int NodesVisited { get; set; }
    public Point Start { get; set; }
    public Point End { get; set; }
}