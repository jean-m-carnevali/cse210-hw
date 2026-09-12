using System;
using System.IO;

// I added that when the .txt files are saved, they are displayed when you enter the number 5.

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        Console.WriteLine("Hello World! This is the Journal Project.");

        int selection = -1;

        while (selection != 6)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Show saved files");
            Console.WriteLine("6. Quit");

            Console.Write("What would you like to do? ");
            selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                DateTime date = DateTime.Now;
                string dateText = date.ToShortDateString();

                string prompText = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompText);
                Console.Write("> ");
                string entryText = Console.ReadLine();

                Entry entry = new Entry(dateText, prompText, entryText);
                journal.AddEntry(entry);
            }

            if (selection == 2)
            {
                journal.DisplayAll();
            }

            if (selection == 3)
            {
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            if (selection == 4)
            {
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }

            if (selection == 5)
            {
                string[] files = Directory.GetFiles(".", "*.txt");
                Console.WriteLine("Saved Files: ");

                if (files.Length == 0)
                {
                    Console.WriteLine("No saved files found");
                }

                else
                {
                    foreach (string file in files)
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }
                }
            }
        }
    }
}