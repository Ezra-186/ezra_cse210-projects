using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake Bread", "Chef Lisa", 540);
        video1.AddComment(new Comment("Mark", "This was super helpful!"));
        video1.AddComment(new Comment("Anna", "Can you do a sourdough one?"));
        video1.AddComment(new Comment("James", "Made this today, loved it!"));
        videos.Add(video1);

        Video video2 = new Video("Mountain Biking Adventure", "Extreme Tim", 420);
        video2.AddComment(new Comment("Sarah", "Whoa that trail was insane."));
        video2.AddComment(new Comment("Chris", "Great camera angles."));
        video2.AddComment(new Comment("Beth", "Made me dizzy lol."));
        videos.Add(video2);

        Video video3 = new Video("Scripture Study Tips", "LDS Tools", 300);
        video3.AddComment(new Comment("Ezra", "This helped my Sunday lesson."));
        video3.AddComment(new Comment("Heather", "I love your explanations!"));
        video3.AddComment(new Comment("Tom", "Bookmarked this!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}
