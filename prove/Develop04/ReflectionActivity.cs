using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private readonly Random _random = new Random();

    public ReflectionActivity(string name, string description) : base(name, description) { }

    public override void Run()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions:");
        ShowSpinner(3);
        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> unusedQuestions = new List<string>(_questions);
        while (DateTime.Now < endTime)
        {
            if (unusedQuestions.Count == 0) unusedQuestions.AddRange(_questions);
            int index = _random.Next(unusedQuestions.Count);
            string question = unusedQuestions[index];
            unusedQuestions.RemoveAt(index);
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}
