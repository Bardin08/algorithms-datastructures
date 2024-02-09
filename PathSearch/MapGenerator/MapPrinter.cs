using System.Text;

namespace PathSearch.MapGenerator;

public static class MapPrinter
{
    public static StringBuilder GetFilledStringBuilder(string[,] maze, List<Point> points,
        Point? start = null, Point? end = null)
    {
        var sb = new StringBuilder();
        points.ForEach(p => maze[p.Column, p.Row] = "·");

        if (start != null) maze[start.Value.Column, start.Value.Row] = "S";
        if (end != null) maze[end.Value.Column, end.Value.Row] = "X";

        PrintTopLine(sb);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            sb.Append($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                sb.Append(maze[column, row]);
            }

            sb.AppendLine();
        }

        return sb;

        void PrintTopLine(StringBuilder stringBuilder)
        {
            stringBuilder.Append(" \t");
            for (var i = 0; i < maze.GetLength(0); i++)
            {
                stringBuilder.Append(i % 10 == 0 ? i / 10 : " ");
            }

            stringBuilder.Append("\n \t");
            for (var i = 0; i < maze.GetLength(0); i++)
            {
                stringBuilder.Append(i % 10);
            }

            stringBuilder.AppendLine("\n");
        }
    }
}