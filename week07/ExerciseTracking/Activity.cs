using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime GetDate() => _date;
    protected int GetMinutes() => _minutes;

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();  


    public string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        string typeName = GetType().Name;

        return $"{dateStr} {typeName} ({_minutes} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min per mile";
    }
}
