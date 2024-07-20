//This is the Event Class
class Event {
    protected string title;
    protected string description;
    protected DateTime dateAndTime;
    protected Address address;

//This will combine all of the information that will be inputed.
    public Event(string title, string description, DateTime dateAndTime, Address address) {
        this.title = title;
        this.description = description;
        this.dateAndTime = dateAndTime;
        this.address = address;
    }

    public virtual string GetStandardDetails() {
        return $"Title: {title}\nDescription: {description}\nDate and Time: {dateAndTime}\nAddress: {address.GetAddressDetails()}";
    }

    public virtual string GetFullDetails() {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription() {
        return $"Event Type: {GetType().Name}\nTitle: {title}\nDate: {dateAndTime}";
    }
}