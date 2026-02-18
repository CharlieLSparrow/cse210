
using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance() => _distanceMiles;

    public override double GetSpeed()
    {

        double hours = GetMinutes() / 60.0;
        return _distanceMiles / hours;
    }

    public override double GetPace()
    {

        return GetMinutes() / _distanceMiles;
    }
}
