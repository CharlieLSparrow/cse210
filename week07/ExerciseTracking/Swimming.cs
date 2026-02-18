using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {

        double meters = _laps * 50.0;
        double km = meters / 1000.0;
        double miles = km / 1.60934;
        return miles;
    }

    public override double GetSpeed()
    {
        double hours = GetMinutes() / 60.0;
        return GetDistance() / hours;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
