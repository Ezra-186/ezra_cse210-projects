using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        Fraction f5 = new Fraction(2, 5);
        Console.WriteLine($"Original f5 → {f5.GetFractionString()}");
        f5.SetTop(7);
        f5.SetBottom(8);
        Console.WriteLine($"After SetTop/SetBottom → {f5.GetFractionString()}");
        Console.WriteLine($"GetTop → {f5.GetTop()}, GetBottom → {f5.GetBottom()}");
    }
}