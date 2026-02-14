using System;
using System.Threading;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected static readonly Random Rand = new();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public string Name => _name;
    public int DurationSeconds => _durationSeconds;

    /// <summary>
    /// Template method: common start -> specialized activity -> common end.
    /// </summary>
    public void Run()
    {
        DisplayStartingMessage();
        DoActivity();
        DisplayEndingMessage();
    }

    protected abstract void DoActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = PromptForDurationSeconds();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    private int PromptForDurationSeconds()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = (Console.ReadLine() ?? "").Trim();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            WriteAndErase(i.ToString(), 1000);
        }
    }

    private static void WriteAndErase(string text, int delayMs)
    {
        Console.Write(text);
        Thread.Sleep(delayMs);

        Console.Write(new string('\b', text.Length));
        Console.Write(new string(' ', text.Length));
        Console.Write(new string('\b', text.Length));
    }
}
