namespace PathSearch.MapGenerator;

public readonly struct Point(int column, int row)
{
    public int Column { get; } = column;
    public int Row { get; } = row;

    public bool Equals(Point other)
    {
        return Column == other.Column && Row == other.Row;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Column, Row);
    }

    public override string ToString()
    {
        return $"r{row}:c{Column}";
    }
}