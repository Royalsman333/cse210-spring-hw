using System;

//Jeremy Untch
//I have accomplished all of the requirements in the activity.
//I have also included an extra option which will allow the user to choose a random activity, instead of having the choose which one they would like to do.
//I have placed the program in a loop so that the user will be able to repeat the activities as many times as they would like.
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

//The reflection activity with properties from activity
class ReflectionActivity : Activity
{
        public ReflectionActivity(int duration = 0) : base(duration, "Reflection")
    {
    }
    //These are the prompts for the reflection activity
    private string[] prompts = {
        "Think about a time when you felt proud of yourself.",
        "Think about a time that you felt comfortable.",
        "Think about a time that you helped somebody.",
        "Think about a time that somebody helped you.",
        "Think about a time when you met your closest friend."
    };

    //These are the questions for the reflection activity.
    private string[] questions = {
        "Why was this experience important to you?",
        "What did you learn from this experience?",
        "How did this experience impact your life?",
        "If you could relive this experience, would you change anything?",
        "Have you had any experiences similar to this one?"
    };

    

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you focus on the good things in life by having you answer questions, and reflect on those moments.");
        //3 second pause
        Thread.Sleep(3000);
    }

    public override void End()
    {
        base.End();
    }
    
    public void Reflect(int numQuestions)
    {
        Random rand = new Random();
        List<string> answeredQuestions = new List<string>();
        //I am asking the user how many questions they want to answer (instead of how long the activity will last).
        Console.WriteLine($"You chose to answer {numQuestions} questions:");

        int promptIndex = rand.Next(prompts.Length);
        string prompt = prompts[promptIndex];

        Console.WriteLine($"Your Prompt is: {prompt}");
        //This will slow down the program allowing the user time to read the prompt.
        ShowSpinner(5);

        //This is where the user will be able to answer the amount of questions that they chose to answer.
        for (int i = 0; i < numQuestions; i++)
        {
            int questionIndex = rand.Next(questions.Length);
            string question = questions[questionIndex];

            //This will give the user a prompt and then a question to answer
            Console.WriteLine($"Question {i + 1}: {question}");
            Console.Write("Your response: ");
            //This will allow the answer to be answered by the user before moving on
            string response = Console.ReadLine();
            //The questiona and answer will then be saved together, so that they can be called upon later.
            answeredQuestions.Add($"{question}: {response}");
        }
        //After the user answers all of the questions, this will list off what the user has answered.
        Console.WriteLine("Good job! Your prompt was {prompt}, and your questions and responses were:");
        foreach (string answeredQuestion in answeredQuestions)
        {
            //This will repeat for each question that was answered.
            Console.WriteLine(answeredQuestion);
        }
    }
}

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

//Actual Program
class Program
{
    static void Main(string[] args)
    {
        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.) Breathing Activity");
            Console.WriteLine("2.) Reflection Activity");
            Console.WriteLine("3.) Listing Activity");
            Console.WriteLine("4.) Random Activity");
            Console.WriteLine("5.) End Program");
            Console.Write("Please Enter Your Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ExecuteBreathingActivity();
                    break;
                case 2:
                    ExecuteReflectionActivity();
                    break;
                case 3:
                    ExecuteListingActivity();
                    break;
                case 4:
                    ExecuteRandomActivity();
                    break;
                case 5:
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Sorry, that is not an option. Please try again.");
                    break;
            }
        }
    }

    //This will activate the Breathing Activity.
    static void ExecuteBreathingActivity()
    {
        Console.Write("Enter amount of breathing repetitions desired: ");
        int duration = int.Parse(Console.ReadLine());
        BreathingActivity breathingActivity = new BreathingActivity(duration);
        breathingActivity.Start();
        while (duration > 0)
        {
            breathingActivity.Breathe();
            duration--;
        }
        breathingActivity.End();
    }

    //This will activate the Reflection Activity
    static void ExecuteReflectionActivity()
    {
        Console.Write("Enter the number of questions you want to answer: ");
        int numQuestions = int.Parse(Console.ReadLine());
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        reflectionActivity.Start();
        reflectionActivity.Reflect(numQuestions);
        reflectionActivity.End();
    }

    //This will activate the listing activity.
    static void ExecuteListingActivity()
        {
            Console.Write("Enter duration (in seconds) for listing items: ");
            int duration = int.Parse(Console.ReadLine());
            ListingActivity listingActivity = new ListingActivity(duration);
            listingActivity.Start();
            listingActivity.ListItemsForDuration(duration);
            listingActivity.End();
        }

    //I added this to allow the user to have the option to get a random activity instead of choosing one.
    static void ExecuteRandomActivity()
    {
        Random random = new Random();
        int choice = random.Next(1, 4); // Randomly choose from available activities

        switch (choice)
        {
            case 1:
                ExecuteBreathingActivity();
                break;
            case 2:
                ExecuteReflectionActivity();
                break;
            case 3:
                ExecuteListingActivity();
                break;
        }
    }
}