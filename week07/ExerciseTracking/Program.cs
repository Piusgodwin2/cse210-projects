using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public double Minutes => _minutes;

    public abstract double GetDistance(); // km or miles depending on your choice
    public abstract double GetSpeed();    // km/h or mph
    public abstract double GetPace();     // min per km or mile

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Minutes} min) - " +
               $"Distance: {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }

    public class Running : Activity
    {
        private double _distance; // km

        public Running(DateTime date, double minutes, double distance)
            : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();
    }

    public class Cycling : Activity
    {
        private double _speed; // km/h

        public Cycling(DateTime date, double minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance() => (_speed * Minutes) / 60;
        public override double GetSpeed() => _speed;
        public override double GetPace() => 60 / _speed;
    }

    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, double minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance() => (_laps * 50) / 1000.0;
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();
    }

     static void Main()
    {    Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 40, 15),
            new Swimming(new DateTime(2022, 11, 3), 25, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}