
public class Entry
{
    public string Date { get; }
    public string PromptText { get; }
    private string _entryText;
    public string EntryText => _entryText;

    public Entry(string date, string prompt, string text)
    {
        Date = date;
        PromptText = prompt;
        _entryText = text;
    }

    public void UpdateText(string newText)
    {
        _entryText = newText;
    }

    public void Display()
    {
        Console.WriteLine($"  Date:     {Date}");
        Console.WriteLine($"  Prompt:   {PromptText}");
        Console.WriteLine($"  Response: {_entryText}");
        Console.WriteLine();
    }
}
