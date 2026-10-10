public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual int GetPoints()
    {
        return _points;
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public string GetSaveDetails()
    {
        return $"{_shortName}|{_description}|{_points}";
    }

    public abstract string GetStringRepresentation();
}