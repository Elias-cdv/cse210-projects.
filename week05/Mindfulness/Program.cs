using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);

        RunActivity();

        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(2);
    }

    protected abstract void RunActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}   ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            elapsed += 4;
            if (elapsed >= _duration) break;

            Console.Write("Now breathe out... ");
            ShowCountdown(6);
            elapsed += 6;
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times when you've shown strength and resilience.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        Console.WriteLine("Consider the following questions:");

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"\n> {question}");
            ShowSpinner(4);
            elapsed += 4;
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you list good things in your life in a specific area.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        Console.WriteLine("You have a few seconds to think...");
        ShowCountdown(5);

        Console.WriteLine("Start listing! (press Enter after each item):");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items. Great job!");
    }
}

class Program
{
    static int breathingCount = 0;
    static int reflectionCount = 0;
    static int listingCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    breathingCount++;
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    reflectionCount++;
                    break;
                case "3":
                    activity = new ListingActivity();
                    listingCount++;
                    break;
                case "4":
                    Console.WriteLine($"\nThanks for using the app!");
                    Console.WriteLine($"Breathing used: {breathingCount} times");
                    Console.WriteLine($"Reflection used: {reflectionCount} times");
                    Console.WriteLine($"Listing used: {listingCount} times");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Start();
            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ReadLine();
        }
    }
}

