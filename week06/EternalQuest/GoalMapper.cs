using System;

public static class GoalMapper
{
    public static Goal FromData(GoalData d)
    {
        return d.Type switch
        {
            "Simple" => new SimpleGoal(d.Name, d.Description, d.Points, d.IsComplete ?? false),
            "Eternal" => new EternalGoal(d.Name, d.Description, d.Points),
            "Checklist" => new ChecklistGoal(
                d.Name,
                d.Description,
                d.Points,
                d.Bonus ?? 0,
                d.Target ?? 0,
                d.Completed ?? 0),
            _ => throw new ArgumentException($"Unknown goal type: {d.Type}")
        };
    }
}
