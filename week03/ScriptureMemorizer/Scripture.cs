using System.Linq;  // for .Select() and .All()

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(part => new Word(part))
                     .ToList();
    }

    public string GetDisplayText()
    {
        string refLine = _reference.GetDisplayText();
        string textLine = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{refLine}\n\n{textLine}";
    }

    public void HideRandomWords(int count)
    {
        var rnd = new Random();
        var available = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && available.Count > 0; i++)
        {
            int idx = rnd.Next(available.Count);
            available[idx].Hide();
            available.RemoveAt(idx);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
