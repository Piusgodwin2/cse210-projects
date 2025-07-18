using System;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;

class Program
{
static List<string> prompts = new List<string>
    {
        "What are you grateful for today? ",
        "What are they goals you're working towards? ",
        "What are the challenges you faced today? ",
        "Write a run down of how your day went: ",
        "list some of your unachieved goals: ",

    };

    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            try
            {
                Console.WriteLine("1. Write a new entry ");
                Console.WriteLine("2. display journal");
                Console.WriteLine("3. load journal");
                Console.WriteLine("4. save journal");
                Console.WriteLine("5. exit");
                Console.Write("Choose an option: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        WriteNewEntry(myJournal);
                        break;
                    case "2":
                        myJournal.DisplayAll();
                        break;
                    case "3":
                        Console.WriteLine("Enter filename to load ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveTofile(saveFile);
                        break;
                    case "4":
                        Console.Write("Write filename to save ");
                        string savefile = Console.ReadLine();
                        myJournal.SaveTofile(savefile);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting the journal application. Goodbye!");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(" Invalid input. Please pick from the options. ");
            }

        }

        static void WriteNewEntry(Journal journal)
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Entry newEntry = new Entry(prompt, response);
            journal.AddEntry(newEntry);
            Console.WriteLine("Entry added successfully!");
        }
    }

}
