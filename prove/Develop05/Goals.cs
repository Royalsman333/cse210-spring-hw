
//This is the goals class. Here is what helps define what a goal is.
public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set;}

//All of my goals are made up of the name of the goal, the short description of the goal, and how many points of the goal is worth.
    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();

    //This is for marking if the goals have been completed or not.
    public abstract bool IsCompleted();

    //This is for saving the goals
    public abstract string GetStringRepresentation();
}