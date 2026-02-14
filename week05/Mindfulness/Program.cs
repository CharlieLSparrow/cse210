using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> sessionLog = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = (Console.ReadLine() ?? "").Trim();

            Activity? activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
            {
                break;
            }

            if (activity is null)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                System.Threading.Thread.Sleep(1200);
                continue;
            }

            activity.Run();
            sessionLog.Add($"{DateTime.Now:HH:mm:ss} - {activity.Name} ({activity.DurationSeconds}s)");

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Session Summary");
        Console.WriteLine("---------------");
        if (sessionLog.Count == 0)
        {
            Console.WriteLine("No activities completed this session.");
        }
        else
        {
            foreach (string entry in sessionLog)
            {
                Console.WriteLine(entry);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }
}
