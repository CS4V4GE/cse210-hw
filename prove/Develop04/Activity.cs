using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name => _name;
    public int Duration => _duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = GetDurationFromUser();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
        Console.Clear();
    }

    public abstract void Run();

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        char[] sequence = { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int index = 0;
        while (DateTime.Now < end)
        {
            Console.Write(sequence[index]);
            Thread.Sleep(150);
            Console.Write('\b');
            index = (index + 1) % sequence.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private int GetDurationFromUser()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a positive whole number.");
        }
    }
}
