//This defines the scriptures. It will call upon the other class to separate the scripture and the reference.
using System.Security.Cryptography;

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

        //This will reveal all words
        public void RevealAllWords()
        {
            foreach (Word word in words)
            {
                word.IsHidden = false;
            }
        }

        //This will hide all words
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
