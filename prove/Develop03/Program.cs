using System;
//Develop 3 Program
//Jeremy Untch
//CSE 210 - Spring Semester
class Program
{
    //This class will help make values for each word in the scriptures
    class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public override string ToString()
        {
            if (IsHidden)
            {
                //Having the value set to one dash per "text.Length" will mean that words with 4 characters will have 4 dashes, whereas words with 2 will have 2. I thought it looked visually better
                return new string('_', Text.Length);
            }
            else
            {
                return Text;
            }
        }
    }

    //This class will define the scripture reference. These next few parts will help me make sure that my scriptures will only hide words in the scripture, instead of the "Reference"
    class ScriptureReference
    {
        public string Reference { get; private set; }

        public ScriptureReference(string reference)
        {
            Reference = reference;
        }

        public override string ToString()
        {
            return Reference;
        }
    }

    //This defines the scriptures. It will call upon the other class to separate the scripture and the reference.
    class Scripture
    {
        //Setting these to private to make sure that they are not manipulated by external code later on.
        private Word[] words;
        private ScriptureReference reference;

        public Scripture(string reference, string text)
        {
            this.reference = new ScriptureReference(reference);
            string[] wordArray = text.Split(' ');
            words = new Word[wordArray.Length];
            for (int i = 0; i < wordArray.Length; i++)
            {
                words[i] = new Word(wordArray[i]);
            }
        }

        //This will make it so a random word will be hidden. This will make sure that words that are already hidden will not be targeted twice.
        public void HideRandomWord()
        {
            Random rand = new Random();
            bool found = false;
            while (!found)
            {
                int index = rand.Next(words.Length);
                if (!words[index].IsHidden)
                {
                    words[index].IsHidden = true;
                    found = true;
                }
            }
        }

        //Once all of the words are hidden, it will label them as hidden. This will help me get out of the loop even if the scripture is very long or very short.
        public bool AllWordsHidden()
        {
            foreach (Word word in words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }

        //Reveal all words
        public void RevealAllWords()
        {
            foreach (Word word in words)
            {
                word.IsHidden = false;
            }
        }

        //Hide all words
        public void HideAllWords()
        {
            foreach (Word word in words)
            {
                word.IsHidden = true;
            }
        }

        public override string ToString()
        {
            return $"{reference}\n{string.Join(" ", Array.ConvertAll(words, w => w.ToString()))}";
        }
    }

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
                                //This will ask if the user would like to memorize anothe scripture (which will send them back to the top, by getting a new scripture to memorize.)
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
