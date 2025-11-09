using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    public override void Run()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();
            if (DateTime.Now >= endTime) break;
            Console.Write("Breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }
    }
}
