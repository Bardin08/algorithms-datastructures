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

var printer = new MapPrinter();

var map = mapGenerator.Generate()!;

var startPoint = new Point(2, 2);
var endPoint = new Point(12, 0);
var endPoint1 = new Point(92, 7);

var pathFinder = new BfsPathFinder();
var shortestPath = pathFinder
    .GetShortestPath(map, startPoint, endPoint)
    .ToList();

printer.Print(map, shortestPath, startPoint, endPoint);