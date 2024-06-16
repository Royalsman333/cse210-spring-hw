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