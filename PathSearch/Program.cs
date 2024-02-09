using DeepCopy;
using PathSearch.MapGenerator;
using PathSearch.PathFinders;

var mapGenerator = new MapGenerator(
    new MapGeneratorOptions
    {
        Height = 10,
        Width = 100,
        Noise = 0.2f,
        Seed = 10233
    });

var map = mapGenerator.Generate()!;
Console.Write(MapPrinter.GetFilledStringBuilder(map, []).ToString());
var startPoint = new Point(2, 2);
var endPoint = new Point(73, 7);

var bfsPathFinderEarlyExit = new BfsPathFinder(useEarlyExit: true);
_ = bfsPathFinderEarlyExit.GetShortestPath(DeepCopier.Copy(map), startPoint, endPoint);

var bfsPathFinderNoEarlyExit = new BfsPathFinder(useEarlyExit: false);
_ = bfsPathFinderNoEarlyExit.GetShortestPath(DeepCopier.Copy(map), startPoint, endPoint);

var dijkstraPathFinder = new DijkstraPathFinder();
_ = dijkstraPathFinder.GetShortestPath(DeepCopier.Copy(map), startPoint, endPoint);

var aStarPathFinder = new AStarPathFinder();
_ = aStarPathFinder.GetShortestPath(DeepCopier.Copy(map), startPoint, endPoint);
