// A simple DTO (data transfer object) used for JSON save/load.
// This keeps the storage format stable even if you refactor class internals.

public class GoalData
{
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Points { get; set; }

    // Optional fields (only used by some goal types)
    public bool? IsComplete { get; set; }
    public int? Bonus { get; set; }
    public int? Target { get; set; }
    public int? Completed { get; set; }
}
