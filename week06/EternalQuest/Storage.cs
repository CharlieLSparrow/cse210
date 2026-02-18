using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class Storage
{
    public static void Save(string path, int score, List<Goal> goals)
    {
        SaveFile file = new SaveFile
        {
            Score = score,
            Goals = goals.Select(g => g.ToData()).ToList()
        };

        string json = JsonSerializer.Serialize(file, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static (int score, List<Goal> goals) Load(string path)
    {
        string json = File.ReadAllText(path);

        SaveFile? file = JsonSerializer.Deserialize<SaveFile>(json);
        if (file == null)
            throw new Exception("Save file was empty or invalid.");

        List<Goal> goals = file.Goals.Select(GoalMapper.FromData).ToList();
        return (file.Score, goals);
    }
}
