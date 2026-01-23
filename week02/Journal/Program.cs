using System;
// Exceeding requirements by adding try catch. I just learned how to use them in JavaScript and Python for use in server requests so I thought it would be cool to learn it in C#.
// Added error handling into prevent the program from crashing if the user enters a file that doesn't exist or is corrupt.
// Added a check in to make sure before wiping the current journal to prevent the user from accidentally losing their current work.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to your journal companion!");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            try 
            {
                if (choice == "1")
                {
                    Entry newEntry = new Entry();
                    DateTime currentTime = DateTime.Now;
                    newEntry._date = currentTime.ToShortDateString();
                    newEntry._promptText = promptGenerator.GetRandomPrompt();
                    
                    Console.WriteLine($"{newEntry._promptText}");
                    Console.Write("> ");
                    newEntry._entryText = Console.ReadLine();

                    theJournal.AddEntry(newEntry);
                }
                else if (choice == "2")
                {
                    theJournal.DisplayAll();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("What is the filename?");
                    string filename = Console.ReadLine();
                    theJournal.LoadFromFile(filename);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("What is the filename?");
                    string filename = Console.ReadLine();
                    theJournal.SaveToFile(filename);
                }
                else if (choice == "5")
                {
                    isRunning = false;
                }
                else 
                {
                    Console.WriteLine("Sorry not an option, choose something from the list.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Shoot, looks like we're getting an error: {ex.Message}");
            }
        }
    }
}