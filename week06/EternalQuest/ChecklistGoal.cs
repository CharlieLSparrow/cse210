using System;

public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _target;
    private int _completed;

    public ChecklistGoal(string name, string description, int points, int bonus, int target, int completed = 0)
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
            return 0;

        _completed++;

        int earned = _points;

        // Bonus is awarded exactly when the goal becomes complete.
        if (IsComplete())
            earned += _bonus;

        return earned;
    }

    public override bool IsComplete() => _completed >= _target;

    public override string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Completed {_completed}/{_target}";
    }

    public override GoalData ToData() => new GoalData
    {
        Type = "Checklist",
        Name = _name,
        Description = _description,
        Points = _points,
        Bonus = _bonus,
        Target = _target,
        Completed = _completed
    };
}
