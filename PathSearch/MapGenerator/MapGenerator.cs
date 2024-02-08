namespace PathSearch.MapGenerator;

public class MapGenerator
{
    private readonly MapGeneratorOptions _options;
    private readonly Random _random;

    private readonly string[,] _maze;

    public MapGenerator(MapGeneratorOptions options)
    {
        _options = options;
        var seed = (int)(options.Seed == -1 ? DateTime.UtcNow.Ticks : options.Seed);
        _random = new Random(seed);

        _maze = new string[options.Width, options.Height];
    }

    public string[,]? Generate()
    {
        return _options.Type == MapType.Maze ? GenerateMaze() : null;
    }

    private string[,] GenerateMaze()
    {
        for (var x = 0; x < _options.Width; x++)
        {
            for (var y = 0; y < _options.Height; y++)
            {
                _maze[x, y] = y % 2 == 1 || x % 2 == 1 ? MapDefaults.Wall : MapDefaults.Space;
            }
        }

        ExpandFrom(new Point(0, 0), []);
        RemoveWalls(_options.Noise);

        // if (_options.AddTraffic)
        // {
        //     AddTraffic(_options.TrafficSeed);
        // }

        return _maze;

        void ExpandFrom(Point point, List<Point> visited)
        {
            visited.Add(point);
            var neighbours = GetNeighbours(point.Column, point.Row, _maze).ToArray();
            Shuffle(neighbours);

            foreach (var neighbour in neighbours)
            {
                if (visited.Contains(neighbour))
                {
                    continue;
                }

                RemoveWallBetween(point, neighbour);
                ExpandFrom(neighbour, visited);
            }
        }
    }

    private void RemoveWallBetween(Point a, Point b)
    {
        _maze[(a.Column + b.Column) / 2, (a.Row + b.Row) / 2] = " ";
    }

    private void Shuffle(IList<Point> array)
    {
        var n = array.Count;
        while (n > 1)
        {
            var k = _random.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }

    private void RemoveWalls(float chance)
    {
        for (var y = 0; y < _maze.GetLength(1); y++)
        {
            for (var x = 0; x < _maze.GetLength(0); x++)
            {
                if (_random.NextDouble() < chance && _maze[x, y] == MapDefaults.Wall)
                {
                    _maze[x, y] = " ";
                }
            }
        }
    }

    private List<Point> GetNeighbours(int column, int row, string[,]? maze, int offset = 2,
        bool checkWalls = false)
    {
        var result = new List<Point>();
        TryAddWithOffset(offset, 0);
        TryAddWithOffset(-offset, 0);
        TryAddWithOffset(0, offset);
        TryAddWithOffset(0, -offset);
        return result;

        void TryAddWithOffset(int offsetX, int offsetY)
        {
            var newColumn = column + offsetX;
            var newRow = row + offsetY;
            if (newColumn >= 0 && newRow >= 0 && newColumn < maze.GetLength(0) && newRow < maze.GetLength(1))
            {
                if (!checkWalls || maze[newColumn, newRow] == MapDefaults.Space)
                {
                    result.Add(new Point(newColumn, newRow));
                }
            }
        }
    }

    // private void AddTraffic(int seed)

    // {

    //     var next = GetNextEmpty();

    //     var trafficRandom = new Random(_options.TrafficSeed);

    //     while (next.HasValue)

    //     {

    //         PaintTrafficDfs(next.Value, trafficRandom.Next(50, 130), trafficRandom.Next(1, 10));

    //         next = GetNextEmpty();

    //     }

    //

    //     return;

    //

    //

    //     Point? GetNextEmpty()

    //     {

    //         for (var y = 0; y < _maze.GetLength(1); y++)

    //         {

    //             for (var x = 0; x < _maze.GetLength(0); x++)

    //             {

    //                 if (_maze[x, y] == " ")

    //                 {

    //                     return new Point(x, y);

    //                 }

    //             }

    //         }

    //

    //         return null;

    //     }

    //

    //     void PaintTrafficDfs(Point point, int depth, int value)

    //     {

    //         var visited = new List<Point>();

    //         var stack = new Stack<Point>();

    //         stack.Push(point);

    //         while (stack.Count > 0 && depth > 0)

    //         {

    //             var next = stack.Pop();

    //             if (visited.Contains(next))

    //             {

    //                 continue;

    //             }

    //

    //             Visit(next);

    //             var neighbours = GetNeighbours(next.Column, next.Row, _maze, 1, true);

    //             foreach (var neighbour in neighbours)

    //             {

    //                 stack.Push(neighbour);

    //             }

    //

    //             void Visit(Point point)

    //             {

    //                 _maze[point.Column, point.Row] = value.ToString();

    //                 depth -= 1;

    //                 visited.Add(point);

    //             }

    //         }

    //     }

    // }
}