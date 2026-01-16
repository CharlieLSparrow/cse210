using System;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> entries = new List<int>();
        int sum = 0;

        Console.WriteLine("Enter a bunch of numbers one at a time then when you're done enter 0 and I'll give you the average! ");
        int entry = int.Parse(Console.ReadLine());
        while (entry != 0) 
        {
            sum += entry;
            entries.Add(entry);
            Console.Write("What you've entered so far: ");
            Console.WriteLine(String.Join(", ", entries));
            entry = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {sum / entries.Count}");
        Console.WriteLine($"Max: {entries.Max()}");
    }
}