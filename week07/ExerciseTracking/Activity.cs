using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    protected Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate() => _date;
    public int GetLength() => _length;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        var dateStr = _date.ToString("dd MMM yyyy");
        var type = GetType().Name;
        return $"{dateStr} {type} ({_length} min)- Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}