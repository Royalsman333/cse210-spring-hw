//This is the Swimming Class under the Activity class
class Swimming : Activity {
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) 
        : base(date, durationMinutes) {
        this.laps = laps;
    }

    public override double GetDistance() {
        double distance = (double)laps * 50 / 1000;
        return distance; 
    }

//To get the speed, I just had to cut the distance by the minutes.
    public override double GetSpeed() {
        double speed = GetDistance() / (durationMinutes / 60.0);
        return speed;
    }

    public override double GetPace() {
        double pace = durationMinutes / GetDistance(); 
        return pace;
    }

    public override string GetSummary() {
        return $"{date.ToShortDateString()} Swimming ({durationMinutes} min) - Distance {GetDistance()} km, Speed {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}