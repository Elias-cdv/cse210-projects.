using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        int result = Square(num);

        Console.WriteLine($"The square of {num} is {result}.");
    }

    static int Square(int number)
    {
        return number * number;
    }
}
