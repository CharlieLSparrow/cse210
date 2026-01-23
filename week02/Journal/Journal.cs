using System;
using System.Collections.Generic;
using System.IO; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry) {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        string filename = file;
        try 
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
    public void LoadFromFile(string file)
    {
        string filename = file;
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return;
            }
            _entries.Clear(); 

            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];
                    loadedEntry._promptText = parts[1];
                    loadedEntry._entryText = parts[2];

                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}