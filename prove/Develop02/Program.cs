using System;
using System.Collections;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;


//Develop 2: Journal Project
//Jeremy Untch

//Making the Entry class, which will combine the Prompt, Response, and Date together.
class Entry
{ 
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n{Response}";
    }
}

//Making the Journal Class, this is where the project will add journal entries and even save them.
class Journal
{
    List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry) => entries.Add(entry);
    public void DisplayJournal() => entries.ForEach(Console.WriteLine);
    //This will allow the user to save the files onto the computer, to later call upon.
    public void SaveToFile(string filename) => File.WriteAllLines(filename, entries.ConvertAll(entry => $"{entry.Prompt}|{entry.Response}|{entry.Date}"));
    //How to load Entries that were previously made
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split("|");
            if (parts.Length == 3)
                entries.Add(new Entry(parts[0], parts[1], parts[2]));
        }
    }

    //This is where I added all of the Prompts for the user, I can add more by placing a comma at the end of the other prompt and then writing more.
    string[] Prompts = { 
        "What was something fun that you did today?",
        "What did you eat today?",
        "What are you goals for this upcoming week?",
        "Who was somebody special that you saw today?",
        "What was your favorite part of the day?",
        "What was your least favorite part of the day?",
        "If you could redo today, what would you change?",
        "On a scale of 1 to 10, how great was today? Why?"
    };
    //This will take a random prompt from my Prompts string.
    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return Prompts[rnd.Next(Prompts.Length)];
    }
}

//This is the actual Program
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        void WriteEntry()
        {
            string prompt = journal.GetRandomPrompt();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine($"Prompt: " + prompt);
            Console.WriteLine(">");
            string response = Console.ReadLine();
            journal.AddEntry(new Entry(prompt, response, date));
        }
        //This will display the user and ask them what they would like to do.
        void DisplayMenu()
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1.) Write");
            Console.WriteLine("2.) Display");
            Console.WriteLine("3.) Load");
            Console.WriteLine("4.) Save");
            Console.WriteLine("5.) Quit Program");
        }
        while(true)
        {
            DisplayMenu();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                //This is where the User can write a new entry
                case "1":
                    WriteEntry();
                    break;
                //This will call upon the Journal Entries that the User has recently made
                case "2":
                    journal.DisplayJournal();
                    break;
                //This is where the user can load up a file that they have previously saved onto the device
                case "3":
                    Console.Write("What is the file name?");
                    journal.LoadFromFile(Console.ReadLine());
                    Console.WriteLine("The file has loaded successfully.");
                    break;
                //This is where the user can save a file, which can later be called upon by case 3.
                case "4":
                    Console.Write("What is the file name?");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("The file has been saved successfully.");
                    break;
                //This will end the Program
                case "5":
                    Console.WriteLine("Quitting Program");
                    return;
                //This will be the default error incase the user inputs an invalid input. This will prevent the program from crashing.
                default:
                    Console.WriteLine("Sorry, that is an invalid input. Please try again");
                    break;
                }
            }
    }
}