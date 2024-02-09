using DeepCopy;
using PathSearch.MapGenerator;
using PathSearch.PathFinders.Statistics;

namespace PathSearch.PathFinders;

public abstract class BasePathFinder(bool useEarlyExit) : IPathFinder, ITypedObservable<PathFinderState>
{
    private static readonly int[] DirectionsRow = [-1, 1, 0, 0]; // Up, Down
    private static readonly int[] DirectionsCol = [0, 0, -1, 1]; // Left, Right

    private readonly List<ITypedObserver<PathFinderState>> _observers = 
    [
        new PathFinderObserver()
    ];

    protected bool EarlyExit { get; } = useEarlyExit;

    public IEnumerable<Point> GetShortestPath(string[,] maze, Point start, Point end)
    {
        var breadcrumbs = GetShortestPathInternal(maze, start, end);
        var path = RestorePath(breadcrumbs, start, end);

        var state = new PathFinderState
        {
            Name = GetType().Name,
            Start = start,
            End = end,
            Map = DeepCopier.Copy(maze),
            Path = DeepCopier.Copy(path),
            NodesVisited = breadcrumbs.Count
        };

        Notify(state);
        return path;
    }

    protected abstract Dictionary<Point, Point?> GetShortestPathInternal(
        string[,] maze, Point start, Point end);

    private List<Point> RestorePath(
        IReadOnlyDictionary<Point, Point?> dictionary, Point start, Point dest)
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

        for (var i = 0; i < 4; i++)
        {
            var newRow = point.Row + DirectionsRow[i];
            var newCol = point.Column + DirectionsCol[i];

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

    public void Subscribe(ITypedObserver<PathFinderState> observer)
    {
        _observers.Add(observer);
    }

    public void Notify(PathFinderState observable)
    {
        _observers.ForEach(x => x.Handle(observable));
    }
}