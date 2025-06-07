public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Exposes the student name for derived classes (e.g. WritingAssignment)
    public string GetStudentName()
    {
        return _studentName;
    }
}
