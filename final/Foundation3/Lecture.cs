//This is the Lecture class (under the Events class.)
class Lecture : Event {
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateAndTime, Address address, string speaker, int capacity)
        : base(title, description, dateAndTime, address) {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails() {
        return base.GetStandardDetails() + $"\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}