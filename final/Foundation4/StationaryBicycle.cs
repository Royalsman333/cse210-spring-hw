//This is the Stationary Bicycle under the Activity class
class StationaryBicycle : Activity {
    private double speed;

    public StationaryBicycle(DateTime date, int durationMinutes, double speed) 
        : base(date, durationMinutes) {
        this.speed = speed;
    }

    public override double GetDistance() {
        return speed * (durationMinutes / 60.0); // Distance in miles
    }

    public override double GetSpeed() {
        return speed;
    }

    public override double GetPace() {
        return 60.0 / speed; // Pace in minutes per mile
    }

    public override string GetSummary() {
        return $"{date.ToShortDateString()} Stationary Bicycle ({durationMinutes} min) - Speed {speed} mph, Pace: {GetPace()} min per mile";
    }
}