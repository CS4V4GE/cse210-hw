using System;
using System.Collections.Generic;
using System.Linq;

namespace HabitTrackerApp
{
    public class HabitTracker
    {
        private List<Habit> _habits = new List<Habit>();

        public void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Habit Tracker");
            Console.WriteLine("Commands: add, record <name>, summary(show), help, quit");
        }

        public bool HandleCommand(string input)
        {
            string[] parts = input.Trim().Split(' ', 2);
            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1] : "";

            switch (command)
            {
                case "add":
                    AddHabit();
                    return false;

                case "record":
                    RecordHabit(argument);
                    return false;

                case "summary":
                    ShowSummary();
                    return false;

                case "help":
                    ShowWelcomeScreen();
                    return false;

                case "quit":
                case "exit":
                    return true;

                default:
                    Console.WriteLine("Unknown command");
                    return false;
            }
        }

        private void AddHabit()
        {
            Console.Write("Habit name: ");
            string name = Console.ReadLine();

            Console.Write("Weekly target: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
            {
                Console.Write("Enter a positive number: ");
            }

            _habits.Add(new Habit(name, target));
            Console.WriteLine("Habit added");
        }

        private void RecordHabit(string name)
        {
            if (_habits.Count == 0)
            {
                Console.WriteLine("No habits exist");
                return;
            }

            Habit habit = FindHabit(name);

            if (habit == null)
            {
                Console.WriteLine("Habit not found");
                return;
            }

            habit.AddCompletion();
            Console.WriteLine(habit.ToString());
        }

        private Habit FindHabit(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            string lowered = input.ToLower();

            return _habits.FirstOrDefault(h =>
                h.Name.ToLower() == lowered ||
                h.Name.ToLower().StartsWith(lowered) ||
                h.Name.ToLower().Contains(lowered));
        }

        private void ShowSummary()
        {
            if (_habits.Count == 0)
            {
                Console.WriteLine("No habits created");
                return;
            }

            foreach (Habit habit in _habits)
            {
                Console.WriteLine(habit.ToString());
            }
        }
    }
}
