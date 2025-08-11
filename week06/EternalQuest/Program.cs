using System;
using System.Collections.Generic;
using System.IO;

// Base Class
abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    // This will be overridden in derived classes where needed
    public virtual string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

    // Record the goal completion and return the points earned
    public abstract int RecordEvent();

    // To save data to file
    public abstract string GetStringRepresentation();
}

// Simple Goal Class
class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points!");
            return Points;
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' already completed!");
            return 0;
        }
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }
}

// Eternal Goal Class
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"Eternal goal '{Name}' recorded! +{Points} points!");
        return Points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}

// Checklist Goal Class
class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted < _target)
        {
            Console.WriteLine($"Progress: {_timesCompleted}/{_target} for '{Name}'. +{Points} points!");
            return Points;
        }
        else if (_timesCompleted == _target)
        {
            Console.WriteLine($"Checklist goal '{Name}' completed! +{Points + _bonus} points!");
            return Points + _bonus;
        }
        else
        {
            Console.WriteLine($"You already completed '{Name}' in full! +{Points} points for extra effort!");
            return Points;
        }
    }

    public override string GetDetailsString()
    {
        string status = _timesCompleted >= _target ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_timesCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_timesCompleted}";
    }
}

// Main Program
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {   
            Console.WriteLine("Hello World! This is the EternalQuest Project.");
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": Console.WriteLine($"Current Score: {score}"); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target times: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            score += goals[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(score);
            foreach (var goal in goals)
            {
                sw.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
        }
        Console.WriteLine("Goals loaded.");
    }
}
