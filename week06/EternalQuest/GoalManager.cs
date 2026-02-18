using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void Start()
    {
        int choice = -1;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            choice = ReadInt("Select a choice from the menu: ", 1, 6);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Later, legend.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first.");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int typeChoice = ReadInt("Which type of goal would you like to create? ", 1, 3);

        string name = ReadString("What is the name of your goal? ");
        string description = ReadString("What is a short description of it? ");
        int points = ReadInt("What is the amount of points associated with this goal? ", 0, int.MaxValue);

        Goal goal;

        if (typeChoice == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (typeChoice == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ", 1, int.MaxValue);
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ", 0, int.MaxValue);
            goal = new ChecklistGoal(name, description, points, bonus, target);
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created.");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet. Create one first.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int goalIndex = ReadInt("Which goal did you accomplish? ", 1, _goals.Count) - 1;

        int earned = _goals[goalIndex].RecordEvent();
        _score += earned;

        if (earned > 0)
            Console.WriteLine($"Nice. You earned {earned} points!");
        else
            Console.WriteLine("No points this time (probably already completed).");

        Console.WriteLine($"You now have {_score} points.");
    }

    private void SaveGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename can't be empty.");
            return;
        }

        try
        {
            Storage.Save(filename, _score, _goals);
            Console.WriteLine("Saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save failed: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file doesn't exist.");
            return;
        }

        try
        {
            (_score, _goals) = Storage.Load(filename);
            Console.WriteLine("Loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load failed: {ex.Message}");
        }
    }

    // ---------- Input helpers ----------
    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }

    private static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }
}
