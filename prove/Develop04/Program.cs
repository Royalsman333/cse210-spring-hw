using System;

//Jeremy Untch
//I have accomplished all of the requirements in the activity.
//I have also included an extra option which will allow the user to choose a random activity, instead of having the choose which one they would like to do.
//I have placed the program in a loop so that the user will be able to repeat the activities as many times as they would like.

//Actual Program
class Program
{
    static void Main(string[] args)
    {
        bool continueProgram = true;
        //This loop will keep the user with the option to do another activity after finishing one.
        while (continueProgram)
        {
            //This is the menu for the user to choose from.
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