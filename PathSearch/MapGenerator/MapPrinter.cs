namespace PathSearch.MapGenerator;

public class MapPrinter
{
    public void Print(string[,] maze, List<Point> points, Point start, Point end)
    {
        points.ForEach(p => maze[p.Column, p.Row] = "·");

        maze[start.Column, start.Row] = "S";
        maze[end.Column, end.Row] = "X";
        
        PrintTopLine();
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                Console.Write(maze[column, row]);
            }

            Console.WriteLine();
        }

        return;

        void PrintTopLine()
        {
            Console.Write(" \t");
            for (var i = 0; i < maze.GetLength(0); i++)
            {
                Console.Write(i % 10 == 0 ? i / 10 : " ");
            }

            Console.Write("\n \t");
            for (var i = 0; i < maze.GetLength(0); i++)
            {
                Console.Write(i % 10);
            }

            Console.WriteLine("\n");
        }
    }
}