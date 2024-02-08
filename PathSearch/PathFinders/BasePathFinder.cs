using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

public abstract class BasePathFinder : IPathFinder
{
    public IEnumerable<Point> GetShortestPath(string[,] maze, Point start, Point end)
    {
        var breadcrumbs = GetShortestPathInternal(maze, start, end);
        return RestorePath(breadcrumbs, start, end);
    }

    protected abstract Dictionary<Point, Point?> GetShortestPathInternal(
        string[,] maze, Point start, Point end);

    private IEnumerable<Point> RestorePath(IReadOnlyDictionary<Point, Point?> dictionary, Point start, Point dest)
    {
        var restoredPath = new List<Point>();

        var current = dest;
        while (!current.Equals(start))
        {
            restoredPath.Add(current);
            current = dictionary[current]!.Value;
        }

        restoredPath.Add(start);
        return restoredPath;
    }

    protected virtual IEnumerable<Point> GetNeighbours(string[,] maze, Point point)
    {
        var neighbors = new List<Point>();

        // Directions arrays represent the relative movements in the 2D grid
        int[] dRow = [-1, 1, 0, 0]; // Up, Down
        int[] dCol = [0, 0, -1, 1]; // Left, Right

        for (var i = 0; i < 4; i++) // Since there are 4 possible directions
        {
            var newRow = point.Row + dRow[i];
            var newCol = point.Column + dCol[i];

            // Check bounds and if the new position is a path
            if (newCol >= 0 && newCol < maze.GetLength(0) &&
                newRow >= 0 && newRow < maze.GetLength(1) &&
                maze[newCol, newRow] is MapDefaults.Space)
            {
                neighbors.Add(new Point(newCol, newRow));
            }
        }

        return neighbors;
    }
}