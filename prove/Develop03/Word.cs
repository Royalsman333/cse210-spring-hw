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