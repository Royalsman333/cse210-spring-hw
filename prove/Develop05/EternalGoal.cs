
//This is the Eternal goals class. It is very similar to the Simple Goals class, but it is obviously made for "Eternal"/ longer goals.
class EternalGoal : Goal
{
    //It is also made up of the goal name, the short goal description, and the amount of points that it is worth.
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsCompleted()
    {
        return false;
    }
        public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }

    public static EternalGoal CreateFromRepresentation(string representation)
    {
        var parts = representation.Split(',');
        var name = parts[0];
        var description = parts[1];
        var points = int.Parse(parts[2]);
        return new EternalGoal(name, description, points);
    }
}