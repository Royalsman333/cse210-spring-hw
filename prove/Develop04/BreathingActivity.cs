//This creates the Breathing Activity while using the Activity properties
class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration, "Breathing")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you relax by guiding you through a breathing excersise.");
        Console.WriteLine("Focus on your breathing...");
        //3 second pause allowing the reader time to read before the activity starts.
        Thread.Sleep(3000);
    }

    public override void End()
    {
        base.End();
    }

//This is the actual Breathing Activity
    public void Breathe()
    {
        Console.WriteLine("Breathe in...");
        //Calling upon the ShowSpinner to add a 3 second pause
        ShowSpinner(3);
        Console.WriteLine("Breathe out...");
        ShowSpinner(3);
    }
}
