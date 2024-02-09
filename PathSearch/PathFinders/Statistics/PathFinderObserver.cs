using System.Text;
using PathSearch.MapGenerator;

namespace PathSearch.PathFinders.Statistics;

public class PathFinderObserver : ITypedObserver<PathFinderState>
{
    public void Handle(PathFinderState context)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Path Finder State: {context.Name}");
        sb.AppendLine($"Nodes Visited: {context.NodesVisited}");
        sb.AppendLine($"Start Point: ({context.Start.Column}, {context.Start.Row})");
        sb.AppendLine($"End Point: ({context.End.Column}, {context.End.Row})");

        if (context.Map != null)
        {
            sb.AppendLine($"Map Size: {context.Map.GetLength(0)}x{context.Map.GetLength(1)}");
        }

        if (context.Path != null)
        {
            sb.AppendLine($"Path Length: {context.Path.Count}");

            if (context.Map != null)
            {
                var mapStringBuilder = MapPrinter.GetFilledStringBuilder(
                    context.Map!, context.Path, context.Start, context.End);

                sb.AppendLine("Path: ");
                sb.Append(mapStringBuilder);
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}
