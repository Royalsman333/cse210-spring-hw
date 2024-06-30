//This is the Checklist class
//This class is a bit more complicated as it has more steps than the simple goals and the eternal goals

class ChecklistGoal : Goal
{
    //Here I have to define three new ints, the TargetCount(the amount of times that you have to complete the goal for a bonus), the CurrentCount(How many times you have completed the goal), and
    //the BonusPoints(how many extra points you will receive once you have achieved your target count.)
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

//Here the ChecklistGoal is put as the name, the short descritpion, the amount of points for each completion, the amount of times you want to accomplish your goal for bonus points, and the amount of bonus points you will receive.
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

//This is the program will track your current count, adding up towards your target count.
    public override int RecordEvent()
    {
        CurrentCount++;
        //Once you achieve your target count, then you will receive the bonus points.
        if (CurrentCount >= TargetCount)
        {
            return Points + BonusPoints;
        }
        return Points;
    }

    public override bool IsCompleted()
    {
        return CurrentCount >= TargetCount;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{TargetCount},{CurrentCount},{BonusPoints}";
    }

    public static ChecklistGoal CreateFromRepresentation(string representation)
    {
        var parts = representation.Split(',');
        var name = parts[0];
        var description = parts[1];
        var points = int.Parse(parts[2]);
        var targetCount = int.Parse(parts[3]);
        var currentCount = int.Parse(parts[4]);
        var bonusPoints = int.Parse(parts[5]);
        return new ChecklistGoal(name, description, points, targetCount, bonusPoints)
        {
            CurrentCount = currentCount
        };
    }
}