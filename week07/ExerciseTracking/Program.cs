using System;
class Program
{
    static void Main(string[] args)
    {
        DateTime dateTime = new DateTime(2022, 11, 3);
        Running running = new Running(30, dateTime, 4.8);
        Cycling cycling = new Cycling(45, dateTime, 20);
        Swimming swimming = new Swimming(30, dateTime, 30);

        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}