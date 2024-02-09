using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

public class DijkstraPathFinder(bool useEarlyExit = true) : BaseHeuristicPathFinder(useEarlyExit)
{
    // Overrides Heuristic to fulfill base class requirements.
    // Dijkstra's algorithm doesn't use a heuristic (it examines all paths for the shortest one),
    // but the method returns a constant to fit into a heuristic-based framework without influencing the algorithm's logic.
    //
    // This approach also ensures compliance with code quality checks that expect less than 3% code duplication.
    protected override int Heuristic(Point p1, Point p2) => 1;
}