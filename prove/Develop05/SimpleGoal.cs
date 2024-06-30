using System;

//This is the subclass for Simple Goals
class SimpleGoal : Goal
{
    private bool _isCompleted;
    
    //The simple goal is just like in the name.. Simple. It has just the name of the goal, the short description of it, and the amount of points that it is worth.
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return Points;
        }
        return 0;
    }

    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_isCompleted}";
    }

    public static SimpleGoal CreateFromRepresentation(string representation)
    {
        var parts = representation.Split(',');
        var name = parts[0];
        var description = parts[1];
        var points = int.Parse(parts[2]);
        var isCompleted = bool.Parse(parts[3]);
        var goal = new SimpleGoal(name, description, points)
        {
            _isCompleted = isCompleted
        };
        return goal;
    }
}
