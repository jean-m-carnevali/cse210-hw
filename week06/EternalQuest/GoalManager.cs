public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals:");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");

            choice = ReadNumber("Select a choice from the menu: ");

            switch (choice){
                case 1: 
                CreateGoal();
                break;
                case 2: 
                ListGoalNames();
                break;
                case 3: 
                SaveGoals();
                break;
                case 4: 
                LoadGoals();
                break;
                case 5: 
                RecordEvent();
                break;
                case 6: 
                Console.WriteLine("Goodbye!");
                break;
                default:
                Console.WriteLine("Invalid option.");
                break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Your level is  {_score / 1000 + 1}\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine($"\nThe goals are:");

        if (_goals.Count == 0)
        {
           Console.WriteLine("No goals created yet.");
           return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string check = goal.IsComplete() ? "X" : " ";
            Console.WriteLine($"{i + 1}. [{check}] {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");

        int type = ReadNumber("Which type of goal would you like to create?.");

        if (type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = (Console.ReadLine() ?? "").Replace("|", " ");

        Console.Write("What is a short description of it? ");
        string description = (Console.ReadLine() ?? "").Replace("|", " ");

        int points = Math.Max(0, ReadNumber("How many points is this goal worth? "));

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }

        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }

        else if (type == 3)
        {
            int target = Math.Max(1, ReadNumber("How many times does this goal need to be accomplished? "));
            int bonus = Math.Max(0, ReadNumber("What is the bonus for completing the goal? "));

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record.");
            return;
        }

        ListGoalNames();
        int number = ReadNumber("Which goal did you accomplish? ");

        if (number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];
        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete!");
            return;
        }

        int previousLevel = _score / 1000 + 1;
        goal.RecordEvent();
        int earnedPoints = goal.GetPoints();
        _score += earnedPoints;

        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");

        int newLevel = _score / 1000 + 1;

        if (newLevel > previousLevel)
        {
            Console.WriteLine($"LEVEL UP! You reached level {newLevel}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception)
        {
            Console.WriteLine("Could not save the goal file");
        }  
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string [] parts = lines[i].Split(":", 2);
                string type = parts[0];
                string[] data = parts[1].Split('|');

                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(data[3]);
                    loadedGoals.Add(new SimpleGoal(name, description, points, isComplete));
                }

                else if (type == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(name, description, points));
                }

                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(data[3]);
                    int bonus = int.Parse(data[4]);
                    int amountCompleted = int.Parse(data[5]);

                    loadedGoals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }

                else
                {
                    throw new FormatException("Unknown goal type.");
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception){
            Console.WriteLine("Could not read the goal file.");
        }
    }

    private int ReadNumber(string message)
    {
        Console.Write(message);
        int number;

        while (!int.TryParse(Console.ReadLine(), out number)){
            Console.Write("Please enter a valid number: ");
        }

        return number;
    }
}