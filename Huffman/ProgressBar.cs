using System.Diagnostics;
using System.Text;

namespace Huffman;


public class ProgressBar
{
    private readonly int _barWidth;
    private readonly string _prefix;
    private readonly long _totalTicks;
    private readonly StringBuilder _bar;
    private readonly Stopwatch _stopwatch;

    private int _currentTick;
    private string _lastRender = string.Empty;

    public ProgressBar(long totalTicks, string prefix = "", int barWidth = 50)
    {
        _barWidth = barWidth;
        _totalTicks = totalTicks;
        _prefix = prefix;
        _bar = new StringBuilder(new string(' ', barWidth));
        _stopwatch = new Stopwatch();

        _currentTick = 0;
        _stopwatch.Start();
    }

    public void Update(int ticks)
    {
        _currentTick += ticks;
        var percentComplete = (double)_currentTick / _totalTicks;
        var ticksToShow = (int)(percentComplete * _barWidth);

        _bar.Clear();
        _bar.Append(new string('=', ticksToShow));
        _bar.Append('>');
        _bar.Append(new string(' ', _barWidth - ticksToShow));

        Render();
    }

    private void Render()
    {
        Console.CursorLeft = 0;
        var elapsed = _stopwatch.Elapsed;
        var elapsedTime =
            $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";
        
        Console.Write($"{_prefix}[{_bar}] {_currentTick}/{_totalTicks} ({_currentTick * 100.0 / _totalTicks:0.00}%) - Time: {elapsedTime}");

        if (_lastRender.Length > Console.CursorLeft)
        {
            Console.Write(new string(' ', _lastRender.Length - Console.CursorLeft));
        }

        _lastRender = Console.CursorLeft.ToString();
    }

    public void Finish()
    {
        _stopwatch.Stop();
        Console.WriteLine();
    }
}