using System;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _currentStreak;
    private DateTime _lastRecordDate;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _currentStreak = 0;
        _lastRecordDate = DateTime.MinValue;
    }

    public void Start()
    {
        string choice;
        do
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Console.WriteLine();
        }
        while (choice != "6");
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter a short description: ");
        string description = Console.ReadLine() ?? "";
        Console.Write("Enter the points for this goal: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the target number of times: ");
                int target = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter the bonus points for completion: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];
            int earned = goal.RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");

            // Daily streak bonus logic
            DateTime today = DateTime.Today;
            if (_lastRecordDate == today.AddDays(-1))
            {
                _currentStreak++;
            }
            else if (_lastRecordDate != today)
            {
                _currentStreak = 1;
            }
            _lastRecordDate = today;

            if (_currentStreak == 7)
            {
                _score += 50;
                Console.WriteLine("7-day streak! Bonus 50 points awarded!");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine() ?? "goals.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine() ?? "";
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':', 2);
                string type = parts[0];
                string[] values = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(values[0], values[1], int.Parse(values[2]));
                        if (bool.Parse(values[3])) sg.RecordEvent();
                        _goals.Add(sg);
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(values[0], values[1], int.Parse(values[2])));
                        break;

                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(
                            values[0], values[1],
                            int.Parse(values[2]),
                            int.Parse(values[4]),
                            int.Parse(values[5]));
                        int completed = int.Parse(values[3]);
                        for (int j = 0; j < completed; j++) cg.RecordEvent();
                        _goals.Add(cg);
                        break;
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
