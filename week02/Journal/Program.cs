// —— Creativity: Beyond core requirements ——
// This program lets the user edit or delete existing entries.
// Before deleting, it displays a numbered list of current entries
// so the user can choose which one to delete.

using System;
public class Program
{
    public static void Main(string[] args)
    {
        var journal = new Journal();
        var promptGen = new PromptGenerator();
        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Edit an entry");
            Console.WriteLine("6. Delete an entry");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    var response = Console.ReadLine();
                    var date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "5":
                    if (journal.Count == 0)
                    {
                        Console.WriteLine("No entries to edit.");
                    }
                    else
                    {
                        Console.WriteLine("Current entries:");
                        journal.DisplayAll();
                        Console.Write("Entry # to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editIndex)
                            && editIndex >= 1 && editIndex <= journal.Count)
                        {
                            Console.Write("New response: ");
                            journal.EditEntry(editIndex - 1, Console.ReadLine());
                            Console.WriteLine($"Entry #{editIndex} updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry number.");
                        }
                    }
                    break;

                case "6":
                    if (journal.Count == 0)
                    {
                        Console.WriteLine("No entries to delete.");
                    }
                    else
                    {
                        Console.WriteLine("Current entries:");
                        journal.DisplayAll();
                        Console.Write("Enter the number of the entry to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delIndex)
                            && delIndex >= 1 && delIndex <= journal.Count)
                        {
                            journal.DeleteEntry(delIndex - 1);
                            Console.WriteLine($"Entry #{delIndex} deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry number.");
                        }
                    }
                    break;

                case "7":
                    // quitting
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}



