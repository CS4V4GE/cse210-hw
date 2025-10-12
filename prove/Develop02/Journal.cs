using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display() {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
        }
        else
        {
            Console.WriteLine("\nJournal Entries:\n");
            foreach (Entry entry in _entries) {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in _entries){
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename) {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines) {
                Entry entry = Entry.FromFileString(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename} successfully");
        }
        else {
            Console.WriteLine($"File not found in directory. (Could not load {filename})");
        }
    }
}
