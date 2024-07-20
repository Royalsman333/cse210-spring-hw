//This is the running class, which is under the Activity class.
class Running : Activity {
    private double distance;

    public Running(DateTime date, int durationMinutes, double distance) 
        : base(date, durationMinutes) {
        this.distance = distance;
    }

    public override double GetDistance() {
        return distance;
    }

    public override double GetSpeed() {
        return distance / (durationMinutes / 60.0); // Speed in miles per hour
    }

    public override double GetPace() {
        return durationMinutes / distance; // Pace in minutes per mile
    }

    public override string GetSummary() {
        return $"{date.ToShortDateString()} Running ({durationMinutes} min) - Distance {distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}