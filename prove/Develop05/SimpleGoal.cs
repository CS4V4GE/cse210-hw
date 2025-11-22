using System;

public class SimpleGoal : Goal
{
    public bool Completed { get; private set; }

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        Completed = completed;
    }

    public override bool IsComplete()
    {
        return Completed;
    }

    public override int RecordEvent()
    {
        if (!Completed)
        {
            Completed = true;
            return Points;
        }

        return 0;
    }

    public override string GetStatus()
    {
        string check = Completed ? "X" : " ";
        return $"[{check}] {Name} ({Description})";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{Completed}";
    }

    public static SimpleGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);
        return new SimpleGoal(name, description, points, completed);
    }
}
