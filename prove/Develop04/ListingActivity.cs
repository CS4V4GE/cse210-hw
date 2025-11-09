using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate? ",
        "What are personal strengths of yours? ",
        "Who are people that you have helped this week? ",
        "When have you felt the Holy Ghost this month? ",
        "Who are some of your personal heroes? "
    };

    private readonly Random _random = new Random();

    public ListingActivity(string name, string description) : base(name, description) { }

    public override void Run()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing. Press Enter after each item.");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items. Nice job!");
    }
}
