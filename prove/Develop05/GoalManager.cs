using System;
using System.Security.Cryptography;

//Here is the Goals Manager class. This is where I keep track of all of the points, the goals, and saving/loading the goals.
//This (apart from the program itself) is one of the most important parts of the program.
class GoalManager
{
    //This is where I keep track of the list of goals that the user has created.
    public List<Goal> Goals { get; private set; }
    
    //This is used for keeping track of the score.
    public int TotalScore { get; private set; }

    public GoalManager()
    {
        Goals = new List<Goal>();
        TotalScore = 0;
    }
    
    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    //Each time the user accomplishes a goal, it will record that it has been completed and it will reward the user with points.
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= Goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        Goal goal = Goals[goalIndex];
        int points = goal.RecordEvent();
        TotalScore += points;

        Console.WriteLine($"Recorded event for goal: {goal.Name}. Points earned: {points}. Total score: {TotalScore}");
    }

    //This is to display all of the goals. I obviously use this when the user chooses the menu option for displaying goals. But I also use it to display the list of goals when the user is going to mark a goal as completed.
    public void DisplayGoals()
    {
        for (int i = 0; i <Goals.Count; i++)
        {
            Goal goal = Goals[i];
            string status = goal.IsCompleted() ? "[X]" : "[ ]";
            if (goal is ChecklistGoal checklistGoal)
            {
                status += $" Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times";
            }
            Console.WriteLine($"{i + 1}. {status} {goal.Name}");
        }
    }

//This is for saving the goals.
    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var goal in Goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

//This is for loading the goals that have been saved.
    public void LoadGoals(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(':');
                var type = parts[0];
                var representation = parts [1];

                Goal goal = type switch
                {
                    "SimpleGoal" => SimpleGoal.CreateFromRepresentation(representation),
                    "EternalGoal" => EternalGoal.CreateFromRepresentation(representation),
                    "ChecklistGoal" => ChecklistGoal.CreateFromRepresentation(representation),
                    _ => throw new NotSupportedException($"Goal type {type} is not supported.")
                };

                Goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }


}