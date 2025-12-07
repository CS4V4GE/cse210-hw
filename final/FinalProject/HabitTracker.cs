using System;
using System.Collections.Generic;
using System.Linq;

namespace HabitTrackerApp
{
    public class HabitTracker
    {
        private readonly List<Habit> _habits = new List<Habit>();

        public void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("        Habit & Exercise Tracker      ");
            Console.WriteLine("======================================");
            Console.WriteLine("Type commands like:");
            Console.WriteLine("  add");
            Console.WriteLine("  record <name>");
            Console.WriteLine("  summary");
            Console.WriteLine("  help");
            Console.WriteLine("  quit");
            Console.WriteLine();
        }

        public bool HandleCommand(string commandLine)
        {
            string trimmed = commandLine.Trim();
            string[]  parts = trimmed.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1].Trim() : string.Empty;

            switch (command)
            {
                case "add":
                case "new":
                case "create":
                    AddHabitInteractive();
                    return false;

                case "record":
                case "done":
                case "log":
                    RecordHabitProgressInteractive(argument);
                    return false;

                case "summary":
                case "list":
                case "show":
                    ShowSummary();
                    return false;

                case "help":
                case "?":
                    ShowHelp();
                    return false;

                case "quit":
                case "exit":
                case "q":
                    return true;
                default:
                    Console.WriteLine($"Unknown command: \"{commandLine}\"");
                    Console.WriteLine("Type 'help' for options.");
                    return false;
                }
        }

        private void ShowHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine("  add");
            Console.WriteLine("  record <name>");
            Console.WriteLine("  summary");
            Console.WriteLine("  help");
            Console.WriteLine("  quit");
        }

        private void AddHabitInteractive()
        {
            Console.WriteLine();
            Console.Write("Habit name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Habit name cannot be empty. Enter name: ");
                name = Console.ReadLine();
            }

            Console.Write("Weekly target: ");
            int weeklyTarget;

            while (!int.TryParse(Console.ReadLine(), out weeklyTarget) || weeklyTarget <= 0)
            {
                Console.Write("Enter a positive number: ");
                weeklyTarget = int.Parse(Console.ReadLine());
            }

            Habit habit = new Habit(name, weeklyTarget);
            _habits.Add(habit);

            Console.WriteLine($"Habit '{habit.Name}' added.");
        }

        private void RecordHabitProgressInteractive(string habitNameArgument)
        {
            if (_habits.Count == 0)
            {
                Console.WriteLine("No habits exist.");
                return;
            }

            Habit selectedHabit = null;

            if (!string.IsNullOrWhiteSpace(habitNameArgument))
            {
                selectedHabit = FindHabitByName(habitNameArgument);

                if (selectedHabit == null)
                {
                    Console.WriteLine($"No habit matches \"{habitNameArgument}\".");
                    PrintHabitList();
                }
            }

            if (selectedHabit == null)
            {
                Console.WriteLine();
                PrintHabitList();
                Console.Write("Enter habit name or number: ");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int index))
                {
                    index -= 1;
                    if (index >= 0 && index < _habits.Count)
                    {
                        selectedHabit = _habits[index];
                    }
                }

                if (selectedHabit == null && !string.IsNullOrWhiteSpace(choice))
                {
                    selectedHabit = FindHabitByName(choice);
                }

                if (selectedHabit == null)
                {
                    Console.WriteLine("Habit not found.");
                    return;
                }
            }

            selectedHabit.AddCompletion();
            Console.WriteLine($"{selectedHabit.Name} updated: {selectedHabit.GetProgress()}");
        }

        public void ShowSummary()
        {
            Console.WriteLine();
            Console.WriteLine("=== Habit Summary ===");

            if (_habits.Count == 0)
            {
                Console.WriteLine("No habits created.");
                return;
            }

            for (int i = 0; i < _habits.Count; i++)
            {
                Habit habit = _habits[i];
                Console.WriteLine($"{i + 1}. {habit}");
            }
        }

        private void PrintHabitList()
        {
            for (int i = 0; i < _habits.Count; i++)
            {
                Habit habit = _habits[i];
                Console.WriteLine($"{i + 1}. {habit.Name} - {habit.GetProgress()}");
            }
        }

        private Habit FindHabitByName(string input)
        {
            string lowered = input.Trim().ToLower();

            Habit match = _habits.FirstOrDefault(h => h.Name.ToLower() == lowered);
            if (match != null) return match;

            match = _habits.FirstOrDefault(h => h.Name.ToLower().StartsWith(lowered));
            if (match != null) return match;

            match = _habits.FirstOrDefault(h => h.Name.ToLower().Contains(lowered));
            return match;
        }
    }
}
