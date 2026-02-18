using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
            return 0;

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override GoalData ToData() => new GoalData
    {
        Type = "Simple",
        Name = _name,
        Description = _description,
        Points = _points,
        IsComplete = _isComplete
    };
}
