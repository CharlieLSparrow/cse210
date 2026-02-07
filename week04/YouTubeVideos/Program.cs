using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How I Edit Podcast Clips Fast", "High Ground Odyssey", 612);
        video1.AddComment(new Comment("Melissa", "This pacing is so much better than last week."));
        video1.AddComment(new Comment("Charlie", "Okay but that metaphor was actually doing cardio."));
        video1.AddComment(new Comment("Alex", "The intro music hits. Keep it."));

        Video video2 = new Video("It’s a Metaphor! (Episode 2)", "High Ground Odyssey", 1840);
        video2.AddComment(new Comment("Scott", "The blocker-word bit made me laugh out loud."));
        video2.AddComment(new Comment("Viewer_42", "I did not expect leadership + aliens, but I’m in."));
        video2.AddComment(new Comment("Sarah", "This feels weirdly wholesome and I appreciate it."));

        Video video3 = new Video("Best Mic Settings in Logic Pro", "Sparrow’s Song Studio", 905);
        video3.AddComment(new Comment("Jay", "The noise gate explanation finally clicked."));
        video3.AddComment(new Comment("Nina", "Can you do a version for Final Cut too?"));
        video3.AddComment(new Comment("Ben", "Saved me hours. Thank you."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"Title:  {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Comments ({video.GetNumberOfComments()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetCommenterName()}: {comment.GetText()}");
            }
        }

        Console.WriteLine("==================================");
    }
}
