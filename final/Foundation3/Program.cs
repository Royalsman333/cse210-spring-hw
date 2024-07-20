using System;
//Program 3 of 4 - Event Planning
//Jeremy Untch

//This is the main program, this is where all of the important information is being stored.
class Program {
    static void Main(string[] args) {
        //This is the event under the lecture class
        Address address = new Address("214 Main St", "Rexburg", "ID", "USA");
        Lecture lecture = new Lecture("How to not immediately get married!", "This lecture will help all BYU-Idaho students learn about the importance of self control when looking for their significant others.", DateTime.Now, address, "John Cena", 100);
        
        //This is the event under the reception class
        address = new Address("451 Smile St", "Twin Falls", "ID", "USA");
        Reception reception = new Reception("Wedding Reception", "My wife and I will be getting married this saturday in the church across from the street.", DateTime.Now, address, "example@example.com");
        
        //This is the event under outdoor gathering
        address = new Address("7821 Solid Oak St", "Jacksonville", "FL", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", DateTime.Now, address, "Sunny");

        //This is where the program will call upon the values and print them all.
        Console.WriteLine("Lecture Marketing Messages:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception Marketing Messages:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering Marketing Messages:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
