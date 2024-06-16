using System;
//Develop 3 Program
//Jeremy Untch
//CSE 210 - Spring Semester


//As extra credit, I have added a counter which will keep track of how many scriptures the user has memorized. After the scripture is completely hidden, the program will ask the user if they
//have memorized the scripture or not. If the user says yes, then counter will go up by one. If the user says no, then the counter will not increase.
//I also added the option to do another scripture or not. If the user does, then the program resets and pulls a new random scripture. The counter will not reset until the program is ended.
//When the program ends, the program will read off to the user the amount of scriptures that they have memorized.


class Program
{
    static void Main(string[] args)
    {
        //These are the scriptures. I can add more if needed by adding a comma behind each scripture (except for the last one) and then following the same format as the others.
        Scripture[] scriptures = new Scripture[]
        {
            new Scripture("1 Nephi 21:16", "Behold, I have graven thee upon the palms of my hands."),
            new Scripture("2 Nephi 23:3", "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."),
            new Scripture("Alma 11:43", "The spirit and the body shall be reunited again in its perfect form."),
            new Scripture("Ether 12:4", "Wherefore, whoso believeth in God might with surety hope for a better world, yea, even a place at the right hand of God, which hope cometh of faith, maketh an anchor to the souls of men, which would make them sure and steadfast."),
            new Scripture("1 Nephi 17:13", "And I will also be your light in the wilderness; and I will prepare the way before you, if it so be that ye shall keep my commandments; wherefore, inasmuch as ye shall keep my commandments ye shall be led towards the promised land; and ye shall know that it is by me that ye are led."),
            new Scripture("2 Corinthians 4:16-18", "So we do not lose heart. Though our outer self is wasting away, our inner self is being renewed day by day. For this light momentary affliction is preparing for us an eternal weight of glory beyond all comparison, as we look not to the things that are seen but to the things that are unseen. For the things that are seen are transient, but the things that are unseen are eternal.")
        };

        int counter = 0;
        bool programRunning = true;

        while (programRunning)
        {
            Random rand = new Random();
            Scripture currentScripture = scriptures[rand.Next(scriptures.Length)];
            currentScripture.RevealAllWords(); // Ensure all words are revealed for the new scripture
            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.Clear();
                Console.WriteLine(currentScripture);
                Console.WriteLine("\nPress enter to hide a word or type 'quit' to end program: ");
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "quit")
                {
                    shouldContinue = false;
                    programRunning = false;
                }
                else
                {
                    currentScripture.HideRandomWord();

                    if (currentScripture.AllWordsHidden())
                    {
                        Console.Clear();
                        foreach (Scripture scripture in scriptures)
                        {
                            scripture.HideAllWords();
                        }

                        Console.WriteLine(currentScripture);
                        Console.WriteLine("\nNow that the scripture is completely covered, try and repeat the scripture from memory!");

                        while (true)
                        {
                            //I added this to ask the user if they have memorized the scripture or not.
                            Console.Write("\nHave you memorized this scripture? (y/n): ");
                            string learned = Console.ReadLine().Trim().ToLower();

                            if (learned == "y")
                            {
                                //If you user has memorized the scripture, it will add one to the counter (which keeps track of the amount of scriptures memorized)
                                Console.Clear();
                                counter++;
                                Console.WriteLine($"\nCongratulations, you have memorized {counter} scripture(s) today!");
                                break;
                            }
                                //If the user did not memorize it, then it will instead just show the scripture in full again and not add anything to the counter.
                            else if (learned == "n")
                            {
                                currentScripture.RevealAllWords();
                                Console.Clear();
                                Console.WriteLine("Let's try again. Here is the scripture with all words revealed:");
                                Console.WriteLine(currentScripture);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that is an invalid input. Please type 'y' to confirm memorization, or 'n' to continue practicing.");
                            }
                        }

                        if (programRunning)
                        {
                            while (true)
                            {
                                //This will ask if the user would like to memorize another scripture (which will send them back to the top, by getting a new scripture to memorize.)
                                Console.Write("\nWould you like to memorize another scripture? (y/n): ");
                                string another = Console.ReadLine().Trim().ToLower();

                                if (another == "y")
                                {
                                    shouldContinue = false;
                                    break;
                                }
                                else if (another == "n")
                                {
                                    shouldContinue = false;
                                    programRunning = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, that is an invalid input. Please type 'y' to memorize another scripture, or 'n' to end the program.");
                                }
                            }
                        }
                    }
                }
            }
        }
        //At the end of the program, I have made it so that it reads off how many scriptures the user memorized.
        Console.Clear();
        Console.WriteLine($"\nCongratulations, you have memorized {counter} scripture(s) today!");
        Console.WriteLine("\nThank you for using my program. Restart the program for a new scripture to learn!");
    }
}
