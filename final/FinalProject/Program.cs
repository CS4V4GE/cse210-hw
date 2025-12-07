using System;

namespace HabitTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HabitTracker tracker = new HabitTracker();
            tracker.ShowWelcomeScreen();

            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Write("\nhabit-tracker> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                exitRequested = tracker.HandleCommand(input);
            }

            Console.WriteLine("Goodbye! Stay strong and don't forget your goal!");
        }
    }
}
