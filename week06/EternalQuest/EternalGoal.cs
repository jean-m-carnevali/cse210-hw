public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }

    public override void RecordEvent()
    {
        Console.WriteLine("Keep up the good work!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetSaveDetails()}";
    }
}