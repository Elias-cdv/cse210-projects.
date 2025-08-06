using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string shortName, string description, int points, int bonusPoints, int targetCount, int currentCount = 0)
        : base(shortName, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override void RecordEvent()
    {
        _currentCount++;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Currently completed: {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonusPoints},{_targetCount},{_currentCount}";
    }
}
