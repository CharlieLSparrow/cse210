using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override GoalData ToData() => new GoalData
    {
        Type = "Eternal",
        Name = _name,
        Description = _description,
        Points = _points
    };
}
