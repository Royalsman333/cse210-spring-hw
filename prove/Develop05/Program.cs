using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//Jeremy Untch
//This is the main program. Here I have the main menu, as well as the results of your choices that you make.
//I tried really hard to use JSON to save and load my code, but after about 3 hours of attempting... I was unsuccessful and decided to go back to the GetStringRepresentation() method.
//I tried to keep my display clean by using Console.Clear() and by adding spacing to the text.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        //I added this because I kept having an error saying that I did not have a "filePath" that existed. Adding this at the beginning of the code cleared up that error.
        string filePath = "goals.txt";

        //This is the main menu options. This will be displayed over and over as long as the user does not end the program (option 6)
        while(true)
        {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("---------------");
            Console.WriteLine("  1.) Create New Goal");
            Console.WriteLine("  2.) List Goals");
            Console.WriteLine("  3.) Save Goals");
            Console.WriteLine("  4.) Load Goals");
            Console.WriteLine("  5.) Record Event");
            Console.WriteLine("  6.) Quit");
            
            string choice = Console.ReadLine();

        //These are the results of the options for the main menu
            switch(choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case"3":
                    SaveGoals(manager, filePath);
                    break;
                case"4":
                    LoadGoals(manager, filePath);
                    break;
                case "5":
                    RecordEvent(manager);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }

//If the user chooses to create a new goal. This menu allows the user to decided which goal they want to create.
    static void CreateNewGoal(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("What type of goal do you wish to create?");
        Console.WriteLine("Your options include...");
        Console.WriteLine("1.) Simple Goal");
        Console.WriteLine("2.) Eternal Goal");
        Console.WriteLine("3.) Checklist Goal)");
        string choice = Console.ReadLine();

    //These are the results of the options for the user to create a new goal.
        switch (choice)
        {
            case "1":
                AddSimpleGoal(manager);
                break;
            case "2":
                AddEternalGoal(manager);
                break;
            case "3":
                AddChecklistGoal(manager);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

//These are the questions that the user will fill out if they decided to add a Simple Goal
    static void AddSimpleGoal(GoalManager manager)
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(name, description, points);
        manager.AddGoal(goal);
        Console.WriteLine("Simple goal added.");
    }

//These are the questions that the user will fill out if they decided to add an Eternal Goal
    static void AddEternalGoal(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(name, description, points);
        manager.AddGoal(goal);
        Console.WriteLine("Eternal goal added.");
    }

//These are the questions that the user will fill out if they decided to add a Checklist Goal
    static void AddChecklistGoal(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int targetCount = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonusPoints = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
        manager.AddGoal(goal);
        Console.WriteLine("Checklist goal added.");
    }

//This is for when the user goes to add an event (when they complete a goal)
    static void RecordEvent(GoalManager manager)
    {
        //I kept finding that my console would be a bit too messy, I just decided that it would be better to clean it up by clearing the console.
        Console.Clear();
        //Here I reprinted the list of goals. This just made it easier for the user to decided which goal they accomplished
        Console.WriteLine("Here is a list of your current goals");
        manager.DisplayGoals();
        Console.WriteLine("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine()) - 1;
        //After the user inputs which goal they added, it will then be recorded in the system and it will mark the goal as completed.
        manager.RecordEvent(index);
    }

//This calls upon the GoalManager class as it saves the goals/files
    static void SaveGoals(GoalManager manager, string filePath)
    {
        manager.SaveGoals(filePath);
    }

//This also calls upon the GoalManager class as it loads the goals/files that have been saved
    static void LoadGoals(GoalManager manager, string filePath)
    {
        manager.LoadGoals(filePath);
    }
}