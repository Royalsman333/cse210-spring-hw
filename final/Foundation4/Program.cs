using System;
//Program 4 of 4 - Exercise Tracking
//Jeremy Untch

//This is the main program, where the information will be added and printed.
class Program {
    static void Main(string[] args) {
        List<Activity> activities = new List<Activity>();

        //Example of the Running Activity
        Running runningActivity = new Running(new DateTime(2023, 12, 4), 30, 3.0);
       
        //Example of the Stationary Bicycle Activity
        StationaryBicycle bicycleActivity = new StationaryBicycle(new DateTime(2022, 11, 3), 30, 12.0);
        
        //Example of the Swimming Activity
        Swimming swimmingActivity = new Swimming(new DateTime(2024, 8, 6), 30, 10);

        //This will add the activities to the activities, which will allow us to print the information off later.
        activities.Add(runningActivity);
        activities.Add(bicycleActivity);
        activities.Add(swimmingActivity);

        //This will display the information
        foreach (Activity activity in activities) {
            Console.WriteLine(activity.GetSummary());
        }
    }
}