﻿using PathSearch.MapGenerator;

namespace PathSearch.PathFinders;

public class BfsPathFinder(bool useEarlyExit = true) : BasePathFinder(useEarlyExit)
{
    protected override Dictionary<Point, Point?> GetShortestPathInternal(
        string[,] maze, Point start, Point end)
    {
        var frontier = new Queue<Point>();
        var path = new Dictionary<Point, Point?>();

        frontier.Enqueue(start);
        path.Add(start, null);

        while (frontier.Count != 0)
        {
            var current = frontier.Dequeue();
            var neighbours = GetNeighbours(maze, current);
            
            if (EarlyExit && current.Equals(end))
            {
                break;
            }

            foreach (var next in neighbours.Where(next => !path.ContainsKey(next)))
            {
                frontier.Enqueue(next);
                path.Add(next, current);
            }
        }

        return path;
    }
}