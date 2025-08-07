using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Class to represent a Comment
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    // Class to represent a Video
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }

        private List<Comment> _comments = new List<Comment>();

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the YouTubeVideos Project.\n");

            // Create video 1
            Video video1 = new Video
            {
                Title = "How to Cook Jollof Rice",
                Author = "Naija Kitchen",
                LengthInSeconds = 420
            };
            video1.AddComment(new Comment("Blessing", "This recipe is fire! 🔥"));
            video1.AddComment(new Comment("Adaeze", "I tried it and it was amazing!"));
            video1.AddComment(new Comment("Zion", "More of this, please!"));

            // Create video 2
            Video video2 = new Video
            {
                Title = "Learn C# in 10 Minutes",
                Author = "CodeMaster",
                LengthInSeconds = 600
            };
            video2.AddComment(new Comment("Mike", "So helpful, thank you!"));
            video2.AddComment(new Comment("Brazil22", "Please make a part 2."));
            video2.AddComment(new Comment("Mile", "Loved how simple you made it."));

            // Create video 3
            Video video3 = new Video
            {
                Title = "How to Dance Shaku Shaku",
                Author = "AfroMoves",
                LengthInSeconds = 315
            };
            video3.AddComment(new Comment("Zainab", "I finally got the steps right!"));
            video3.AddComment(new Comment("Kunle", "This was too much fun."));
            video3.AddComment(new Comment("Ngozi", "I laughed so hard trying this 😂"));

            // Create video 4
            Video video4 = new Video
            {
                Title = "Top 10 Nigerian Movies of 2025",
                Author = "NollyBuzz",
                LengthInSeconds = 700
            };
            video4.AddComment(new Comment("Chris", "I agree with this list!"));
            video4.AddComment(new Comment("Precious", "Where is 'The Royal Truth'?"));
            video4.AddComment(new Comment("Debbylove", "This was nicely done."));

            // Put videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3, video4 };

            // Display info for each video
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.Name}: {comment.Text}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}