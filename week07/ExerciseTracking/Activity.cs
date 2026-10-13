public abstract class Activity
{
    private int _minutes;
    private DateTime _dateTime;

    public Activity(int minutes, DateTime dateTime)
    {
        _minutes = minutes;
        _dateTime = dateTime;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();


    public string GetSummary()
    {
        return $"{_dateTime:dd MMM yyyy} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}