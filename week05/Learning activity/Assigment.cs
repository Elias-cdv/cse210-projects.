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

    // Método para acceder al nombre si se necesita desde clases hijas
    public string GetStudentName()
    {
        return _studentName;
    }
}
