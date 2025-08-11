using System;

public class Duration 
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        totalSeconds %= 3600;
        Minutes = totalSeconds / 60;
        Seconds = totalSeconds % 60;
    }

    public Duration(Duration d)
    {
        Hours = d.Hours;
        Minutes = d.Minutes;
        Seconds = d.Seconds;
    }

    // Operator overloads
    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
    }

    public static Duration operator +(Duration d1, int seconds)
    {
        return new Duration(d1.ToSeconds() + seconds);
    }

    public static Duration operator +(int seconds, Duration d1)
    {
        return new Duration(d1.ToSeconds() + seconds);
    }

    public static Duration operator ++(Duration d)
    {
        return new Duration(d.ToSeconds() + 60);
    }

    public static Duration operator --(Duration d)
    {
        return new Duration(d.ToSeconds() - 60);
    }

    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(d1.ToSeconds() - d2.ToSeconds());
    }

    public static Duration operator -(Duration d1, int seconds)
    {
        return new Duration(d1.ToSeconds() - seconds);
    }

    public static Duration operator -(int seconds, Duration d1)
    {
        return new Duration(seconds - d1.ToSeconds());
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return d1.ToSeconds() > d2.ToSeconds();
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return d1.ToSeconds() < d2.ToSeconds();
    }

    public static bool operator ==(Duration d1, Duration d2)
    {
        if (ReferenceEquals(d1, null) && ReferenceEquals(d2, null)) return true;
        if (ReferenceEquals(d1, null) || ReferenceEquals(d2, null)) return false;
        return d1.ToSeconds() == d2.ToSeconds();
    }

    public static bool operator !=(Duration d1, Duration d2)
    {
        return !(d1 == d2);
    }

    public static bool operator true(Duration d)
    {
        return (d.Hours + d.Minutes + d.Seconds) > 0; 
    }

    public static bool operator false(Duration d)
    {
        return (d.Hours + d.Minutes + d.Seconds) == 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Duration d)
            return this == d;
        return false;
    }

    public override int GetHashCode()
    {
        return ToSeconds().GetHashCode();
    }

    public int ToSeconds()
    {
        return (Hours * 3600) + (Minutes * 60) + Seconds;
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
}

class Program
{
    static void Main()
    {
        Duration d1 = new Duration(1, 20, 30);
        Duration d2 = new Duration(0, 40, 50);

        Duration sum = d1 + d2;
        Console.WriteLine("Sum: " + sum);

        Duration diff = d1 - d2;
        Console.WriteLine("Difference: " + diff);

        Duration inc = ++d1;
        Console.WriteLine("Increment: " + inc);

        Duration dec = --d2;
        Console.WriteLine("Decrement: " + dec);

        Console.WriteLine(d1 > d2 ? "d1 is greater" : "d2 is greater");
        Console.WriteLine(d1 == d2 ? "Equal" : "Not Equal");
    }
}
