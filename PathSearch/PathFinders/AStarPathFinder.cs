using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

public class AStarPathFinder(bool useEarlyExit = true) : BaseHeuristicPathFinder(useEarlyExit)
{
    protected override int Heuristic(Point end, Point next) =>
        Math.Abs(end.Column - next.Column) + Math.Abs(end.Row - next.Row);
}