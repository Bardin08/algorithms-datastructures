using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

interface IPathFinder
{
    IEnumerable<Point> GetShortestPath(string[,] maze, Point start, Point end);
}