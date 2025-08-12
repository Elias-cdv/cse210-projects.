using System;
using System.Collections.Generic;
using System.Globalization;

abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime Date => _date;
    public int Length => _length;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)} " +
               $"{this.GetType().Name} ({_length} min) - " +
               $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return GetDistance() * 60 / Length;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (Length / 60.0);
    }

    public override double GetSpeed() => _speed;

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50.0;
    private const double MetersToMiles = 0.000621371;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMeters * MetersToMiles;
    }

    public override double GetSpeed()
    {
        return GetDistance() * 60 / Length;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 30, 12.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
