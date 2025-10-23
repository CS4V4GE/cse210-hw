using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal= new Journal();
        PromptGenerator promptGenerator= new PromptGenerator();

        bool running= true;

        while (running == true) {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("-- ");
                    string response = Console.ReadLine();
                    Entry newEntry = new Entry(prompt, response, DateTime.Now.ToShortDateString());
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid operation. Try again.");
                    break;
            }
        }
    }
}
