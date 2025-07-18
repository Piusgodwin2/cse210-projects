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

    public void DisplayAll() // display the entry
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveTofile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}\n{entry.Prompt}\n{entry.Response}\n");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { '\n' }, 3);
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[1], parts[2]);
                    entry.Date = parts[0];
                    _entries.Add(entry);
                }
            }
                Console.WriteLine($"Journal loaded from {filename}");
            }
            else
            {
                Console.WriteLine($"File {filename} does not exist.");
            }
        }
}