using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Practice Better", "Sparrow’s Song Studio", 540);
        video1.AddComment(new Comment("Melissa", "The 2-minute rule is so helpful."));
        video1.AddComment(new Comment("Charlie", "I tried this and my brain stopped fighting me."));
        video1.AddComment(new Comment("Nina", "Can you do one on warmups next?"));
        videos.Add(video1);

        Video video2 = new Video("It’s a Metaphor! (Episode 2)", "High Ground Odyssey", 1840);
        video2.AddComment(new Comment("Scott", "Blocker words… that’s hilarious and true."));
        video2.AddComment(new Comment("Alex", "The banter is getting really good."));
        video2.AddComment(new Comment("Viewer_42", "I did not expect aliens + leadership. I’m in."));
        videos.Add(video2);

        Video video3 = new Video("Logic Pro Noise Cleanup Basics", "High Ground Odyssey", 725);
        video3.AddComment(new Comment("Jay", "This saved my outdoor recording."));
        video3.AddComment(new Comment("Sarah", "The before/after difference is wild."));
        video3.AddComment(new Comment("Ben", "Please cover De-esser settings too."));
        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Title:  {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Comments ({video.GetNumberOfComments()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }
        }

        Console.WriteLine("======================================");
    }
}
