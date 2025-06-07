using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
          )
    { }

    private void ShowBreathingCountdown(int totalSeconds)
    {
        const int steps = 20;
        double frameMs = totalSeconds * 1000.0 / steps;

        Console.Write("[");
        for (int i = 0; i < steps; i++)
        {
            Console.Write("■");
        }
        Console.Write("]");

        for (int i = 0; i < steps; i++)
        {
            Thread.Sleep((int)frameMs);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0) break;

            Console.WriteLine($"\nTime remaining: {remaining} second{(remaining == 1 ? "" : "s")}");

            int inhaleTime, exhaleTime;
            if (remaining >= 10)
            {
                inhaleTime = 4;
                exhaleTime = 6;
            }
            else
            {
                inhaleTime = (int)Math.Ceiling(remaining / 2.0);
                exhaleTime = remaining - inhaleTime;
                if (exhaleTime < 1) exhaleTime = 1;
            }

            Console.WriteLine("Breathe in...");
            ShowBreathingCountdown(inhaleTime);

            Console.WriteLine("Breathe out...");
            ShowBreathingCountdown(exhaleTime);
        }

        DisplayEndingMessage();
    }
}
