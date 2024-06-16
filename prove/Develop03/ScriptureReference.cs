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