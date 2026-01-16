using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomMagic = new Random();
        int magicNumber = randomMagic.Next(1, 101);
        int guess = 101;
        Console.WriteLine("Guess that number!");

        while (guess != magicNumber) {
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess) {
                Console.WriteLine("Too low");
            } else if (magicNumber < guess) {
                Console.WriteLine("Too high");
            } else {
                Console.WriteLine("That's it!");
            }
        }
    }
}