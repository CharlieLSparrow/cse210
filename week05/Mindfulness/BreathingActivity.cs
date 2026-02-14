using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            name: "Breathing",
            description: "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void DoActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0) break;

            int inhale = Math.Min(4, remaining);
            Console.Write("Breathe in... ");
            ShowCountdown(inhale);
            Console.WriteLine();

            remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0) break;

            int exhale = Math.Min(4, remaining);
            Console.Write("Breathe out... ");
            ShowCountdown(exhale);
            Console.WriteLine();
        }
    }
}
