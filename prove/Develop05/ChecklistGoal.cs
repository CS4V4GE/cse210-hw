using System;

public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = currentCount;
    }

    public override bool IsComplete()
    {
        return CurrentCount >= TargetCount;
    }

    public override int RecordEvent()
    {
        CurrentCount++;
        int total = Points;
        if (CurrentCount == TargetCount)
        {
            total += BonusPoints;
        }
        return total;
    }

    public override string GetStatus()
    {
        string check = IsComplete() ? "X" : " ";
        return $"[{check}] {Name} ({Description}) -- Completed {CurrentCount}/{TargetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{TargetCount}|{BonusPoints}|{CurrentCount}";
    }

    public static ChecklistGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int targetCount = int.Parse(parts[4]);
        int bonusPoints = int.Parse(parts[5]);
        int currentCount = int.Parse(parts[6]);

        return new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount);
    }
}
