using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2026, 2, 18), 30, 3.0),
            new Cycling(new DateTime(2026, 2, 18), 45, 16.0),
            new Swimming(new DateTime(2026, 2, 18), 40, 60)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
