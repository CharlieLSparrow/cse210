using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private readonly List<string> _promptPool = new();
    private readonly List<string> _questionPool = new();

    // Optional: avoid repeats until the pool is exhausted.
    private readonly List<string> _availablePrompts = new();
    private readonly List<string> _availableQuestions = new();

    public ReflectionActivity()
        : base(
            name: "Reflection",
            description: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptPool.AddRange(new[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        _questionPool.AddRange(new[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });

        _availablePrompts.AddRange(_promptPool);
        _availableQuestions.AddRange(_questionPool);
    }

    protected override void DoActivity()
    {
        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = TakeRandomNonRepeating(_availablePrompts, _promptPool);
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            string question = TakeRandomNonRepeating(_availableQuestions, _questionPool);
            Console.Write($"> {question} ");

            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int pauseSeconds = Math.Min(6, Math.Max(1, remaining));
            ShowSpinner(pauseSeconds);

            Console.WriteLine();
        }
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
