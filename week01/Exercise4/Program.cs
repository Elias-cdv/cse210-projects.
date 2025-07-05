using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input = -1;

        while (input != 0)
        {
            Console.Write("Enter a number (0 to stop): ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {(float)sum / numbers.Count}");
    }
}
