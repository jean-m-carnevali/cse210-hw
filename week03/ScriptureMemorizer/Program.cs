using System;

// I added a library with three scriptures so one of them appears randomly each time the program starts.
class Program
{
    static void Main(string[] args)
    {

        List<Scripture> scriptureLibrary = new List<Scripture>();

        Reference reference1 = new Reference("Proverbs", 3, 5, 6);
        string text1 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " + "In all thy ways acknowledge him, and he shall direct thy paths.";

        scriptureLibrary.Add(new Scripture(reference1, text1));

        Reference reference2 = new Reference("Jhon", 3, 16);
        string text2 = "For God so loved the world, that he gave his only begotten Son, " + "that whosoever believeth in him should not perish, but have everlasting life.";

        scriptureLibrary.Add(new Scripture(reference2, text2));

        Reference reference3 = new Reference("1 Nephi", 3, 7);
        string text3 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, " + "for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them " + "that they may accomplish the thing which he commandeth them.";

        scriptureLibrary.Add(new Scripture(reference3, text3));

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[index];

        string input = "";

        while(input != "quit" && scripture.IsCompletelyHidden() == false)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();

            if (input != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
        if(scripture.IsCompletelyHidden() == true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}