//This is the Reception class (under the Events class as well).
class Reception : Event {
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateAndTime, Address address, string rsvpEmail)
        : base(title, description, dateAndTime, address) {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails() {
        return base.GetStandardDetails() + $"\nRSVP Email: {rsvpEmail}";
    }
}