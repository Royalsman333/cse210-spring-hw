//Listing Activity with Activity properties
class ListingActivity : Activity
{
    // The prompts to the activity
    private string[] prompts = {
        "Who are some important people in your life?",
        "What is something that you could not live without?",
        "What are some ways that you can improve yourself starting today?",
        "What spiritual experiences have you had this month?"
    };

    public ListingActivity(int duration) : base(duration, "Listing")
    {}

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on certain questions, then you will be asked to list off answers about those questions.");
        // 3 second pause
        Thread.Sleep(3000);
    }

    public override void End()
    {
        base.End();
    }

    public void ListItemsForDuration(int duration)
    {
        Random rand = new Random();
        // Get a random prompt
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine("Prompt: " + prompt);
        //I added the spinner here to allow the user time to think about the prompt.
        ShowSpinner(5);

        Console.WriteLine("You have chosen to list items for " + duration + " seconds.");
        Console.WriteLine("You can start listing now!");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new List<string>();

        // Allow the user to input items until the specified duration
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item or 'done' to finish: ");
            string item = Console.ReadLine();
            if (item.ToLower() != "done")
            {
                items.Add(item);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("Items listed:");
        foreach (string item in items)
        {
            Console.WriteLine("- " + item);
        }

        Console.WriteLine($"Number of items listed: {items.Count}");
    }
}