using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;

    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description})";
    }

    // Returns the number of points earned for recording the event.
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // Convert to DTO for JSON save/load (Approach B).
    public abstract GoalData ToData();
}
