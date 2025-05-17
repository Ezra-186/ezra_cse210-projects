
public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public int Count => _entries.Count;

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:");
            _entries[i].Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
                writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
        }
    }

    public void EditEntry(int index, string newText)
    {
        if (index >= 0 && index < _entries.Count)
            _entries[index].UpdateText(newText);
    }

    public void DeleteEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
            _entries.RemoveAt(index);
    }
}
