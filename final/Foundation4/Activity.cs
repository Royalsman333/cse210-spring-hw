//This is the Activity class, this will be used as the base for all of our other classes.
abstract class Activity {
    protected DateTime date;
    protected int durationMinutes;

    public Activity(DateTime date, int durationMinutes) {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}