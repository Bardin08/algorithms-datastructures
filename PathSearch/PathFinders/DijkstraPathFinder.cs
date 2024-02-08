using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

public class DijkstraPathFinder : BasePathFinder
{
    protected override Dictionary<Point, Point?> GetShortestPathInternal(
        string[,] maze, Point start, Point end)
    {
        var frontier = new PriorityQueue<Point, int>();
        var path = new Dictionary<Point, Point?>();
        var costs = new Dictionary<Point, int>();

        path[start] = null;
        costs[start] = 0;
        frontier.Enqueue(start, 0);

        while (frontier.Count != 0)
        {
            var current = frontier.Dequeue();
            var neighbours = GetNeighbours(maze, current);

            if (current.Equals(end))
            {
                break;
            }

            foreach (var next in neighbours.Where(next => !path.ContainsKey(next)))
            {
                var newCost = costs[current] + GetCost(current, next);
                if (costs.TryGetValue(next, out var value) && newCost >= value)
                {
                    continue;
                }

                costs[next] = newCost;
                frontier.Enqueue(next, newCost);
                path[next] = current;
            }
        }

        return path;
    }

    private int GetCost(Point current, Point next) => 1;
}