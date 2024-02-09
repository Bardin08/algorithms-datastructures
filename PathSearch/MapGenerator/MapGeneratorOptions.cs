namespace PathSearch.MapGenerator;

public record MapGeneratorOptions
{
    public int Width { get; init; }

    public int Height { get; init; }

    public MapType Type { get; init; } = MapType.Maze;

    public float Noise { get; init; }

    public int Seed { get; init; } = -1;

    public bool AddTraffic { get; init; }

    public int TrafficSeed { get; init; }
}