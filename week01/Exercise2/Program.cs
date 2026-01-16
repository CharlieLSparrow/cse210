using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string percent = Console.ReadLine();
        int grade = int.Parse(percent);
        char letterGrade;
        bool isPassing;
        
        if (grade >= 90) {
            letterGrade = 'A';
        } else if (grade >= 80) {
            letterGrade = 'B';
        } else if (grade >= 70) {
            letterGrade = 'C';
        } else if (grade >= 60) {
            letterGrade = 'D';
        } else {
            letterGrade = 'F';
        }

        if (grade >= 70) {
            isPassing = true;
        } else {
            isPassing = false;
        }

        if (isPassing){
            Console.WriteLine($"Nice work! {letterGrade} means you passed!");
        } else {
            Console.WriteLine($"I'm sorry {letterGrade} isn't passing, but you'll get it next time!");
        }
    }
}