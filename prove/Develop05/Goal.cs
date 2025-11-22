using System;

public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }
    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
    public static Goal Deserialize(string line)
    {
        string[] parts = line.Split('|');
        string type = parts[0];

        if (type == "SimpleGoal")
        {
            return SimpleGoal.Deserialize(parts);
        }
        else if (type == "EternalGoal")
        {
            return EternalGoal.Deserialize(parts);
        }
        else if (type == "ChecklistGoal")
        {
            return ChecklistGoal.Deserialize(parts);
        }

        throw new InvalidOperationException("Unknown goal type");
    }
}
