using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _promptPool = new();

    // Extra avoids repeats until the pool is exhausted.
    private readonly List<string> _availablePrompts = new();

    public ListingActivity()
        : base(
            name: "Listing",
            description: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptPool.AddRange(new[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

        _availablePrompts.AddRange(_promptPool);
    }

    protected override void DoActivity()
    {
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = TakeRandomNonRepeating(_availablePrompts, _promptPool);
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
    }

    private static string TakeRandomNonRepeating(List<string> available, List<string> full)
    {
        if (available.Count == 0)
        {
            available.AddRange(full);
        }

        int index = Rand.Next(available.Count);
        string value = available[index];
        available.RemoveAt(index);
        return value;
    }
}
