using System;

// EXCEEDS REQUIREMENTS:
// I really had fun with this assignment so I added some extra things:
//  - logs each session to a simple in-memory list for potential future export
//  - for sessions under 10s, split the remaining time into inhale/exhale halves
//  - validate user input for duration to avoid crashes on non-numeric or empty input
//  - shrinking countdown bar so the user sees exactly when the breath ends
//  - show a live countdown of seconds remaining


public class Program
{
    private static List<string> _sessionLog = new();

    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine()!;
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (choice == "4") break;
            if (activity == null)
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            activity.Run();
            _sessionLog.Add($"{activity.GetName()} for {activity.GetDuration()}s at {DateTime.Now}");
        }

        Console.WriteLine("Thank you for using Mindfulness Program!");
    }
}
