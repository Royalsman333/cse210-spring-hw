//This is the Outdoor Gathering class (under the Event class)
class OutdoorGathering : Event {
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateAndTime, Address address, string weatherForecast)
        : base(title, description, dateAndTime, address) {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails() {
        return base.GetStandardDetails() + $"\nWeather Forecast: {weatherForecast}";
    }
}