class Activity
{
    int duration;
    string name;

    public Activity(int duration, string name)
    {
        this.duration = duration;
        this.name = name;
    }

    public virtual void Start()
    {
        //The start up messages for each activty.
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine("Lets begin...");
        //This will pause the program for 3 seconds.
        Thread.Sleep(3000);
    }

    public virtual void End()
    {
        //The messages at the end of each activity.
        Console.WriteLine("Good Job!");
        Console.WriteLine($"You have completed the {name} activity.");
        //This will pause the proogram for another 3 seconds.
        Thread.Sleep(3000);
    }

    //This is what will activate the loading spinner.
    public void ShowSpinner(int seconds)
    {
        
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}