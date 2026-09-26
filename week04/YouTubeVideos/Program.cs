using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Make Pancakes", "Cooking easy", 300);

        video1.AddComment(new Comment("Paul", "This recipe is very easy."));
        video1.AddComment(new Comment("Jean", "I made these pancakes today."));
        video1.AddComment(new Comment("Marco", "They look delicious! "));
        video1.AddComment(new Comment("Juan", "This video helped me make the dinner."));

        Video video2 = new Video("How to learn English", "English lessons", 450);

        video2.AddComment(new Comment("David", "This video helped me a lot, Thank you!."));
        video2.AddComment(new Comment("Maria", "Very useful tips."));
        video2.AddComment(new Comment("Jenn", "I am practicing every day!"));
        video2.AddComment(new Comment("Duolingo", "Or... you can use Duolingo :)"));

        Video video3 = new Video("10 Minute Workout", "Fitness in home", 603);

        video3.AddComment(new Comment("Carlos", "Great workout!"));
        video3.AddComment(new Comment("Emily", "Perfect for beginners."));
        video3.AddComment(new Comment("Caroline", "I will do this every morning."));

        Video video4 = new Video("10 Places to Visit in Colombia", "Jhon in Colombia", 900);

        video4.AddComment(new Comment("Franco", "I want to visit Cartagena!"));
        video4.AddComment(new Comment("Sophia", "Medellin looks amazing."));
        video4.AddComment(new Comment("Zara", "Bogotá is definitely on my travel list!"));
        video4.AddComment(new Comment("Omar", "Great recommendations!"));


        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine($"Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(comment.GetDisplayText());
            }

            Console.WriteLine();
        }
    }
}