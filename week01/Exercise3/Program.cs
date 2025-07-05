using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Counting from 1 to 10:");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nNow enter numbers. Type 0 to stop:");
        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
        } while (number != 0);

        Console.WriteLine("Finished!");
    }
}
