using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video { Title = "The Rise of AI", Author = "John Tech", Length = 320 };
        video1.AddComment(new Comment("Sarah", "This video blew my mind!"));
        video1.AddComment(new Comment("Tom", "Great insights."));
        video1.AddComment(new Comment("Maya", "So interesting!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video { Title = "How to Cook Pasta", Author = "Chef Mario", Length = 210 };
        video2.AddComment(new Comment("Anna", "Delicious recipe!"));
        video2.AddComment(new Comment("Lucas", "Thanks, this helped a lot."));
        video2.AddComment(new Comment("Zoe", "Looks so yummy!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video { Title = "Guitar Tutorial", Author = "StrumMaster", Length = 450 };
        video3.AddComment(new Comment("Dave", "Finally learned the intro riff!"));
        video3.AddComment(new Comment("Nina", "Can you make a part 2?"));
        video3.AddComment(new Comment("Ben", "Very clear explanations."));
        videos.Add(video3);

        // Show all videos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
