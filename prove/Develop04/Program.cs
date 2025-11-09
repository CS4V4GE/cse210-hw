using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    private static Dictionary<string, (int count, int totalSeconds)> _activityLog = new Dictionary<string, (int count, int totalSeconds)>();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("CSE 210: Programming with Classes ");
            Console.WriteLine("Mindfulness Program ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Breathing Activity ");
            Console.WriteLine("2. Reflection Activity ");
            Console.WriteLine("3. Listing Activity ");
            Console.WriteLine("4. View Session Summary ");
            Console.WriteLine("5. Quit ");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."));
                    break;
                case "2":
                    RunActivity(new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."));
                    break;
                case "3":
                    RunActivity(new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."));
                    break;
                case "4":
                    ShowSessionSummary();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Program. Press Enter to exit.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option (1-5).");
                    PauseAndReturn();
                    break;
            }
        }
    }

    private static void RunActivity(Activity activity)
    {
        activity.Start();
        activity.Run();
        activity.End();
        string name = activity.Name;
        int duration = activity.Duration;
        if (_activityLog.ContainsKey(name))
        {
            var entry = _activityLog[name];
            _activityLog[name] = (entry.count + 1, entry.totalSeconds + duration);
        }
        else
        {
            _activityLog[name] = (1, duration);
        }
    }

    private static void ShowSessionSummary()
    {
        Console.Clear();
        Console.WriteLine("Session Summary");
        Console.WriteLine("---------------");
        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No activities completed yet this session.");
        }
        else
        {
            foreach (var kvp in _activityLog)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.count} time, in {kvp.Value.totalSeconds} total seconds");
            }
        }
        PauseAndReturn();
    }

    private static void PauseAndReturn()
    {
        Console.WriteLine();
        Console.Write("Press Enter to return to the menu...");
        Console.ReadLine();
    }
}
