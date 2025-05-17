
public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "Who did you talk to today that made you smile?",
        "What is something you learned today?",
        "Describe a moment you felt peace.",
        "What is a goal you have for tomorrow?"
    };

    public string GetRandomPrompt()
    {
        var rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
