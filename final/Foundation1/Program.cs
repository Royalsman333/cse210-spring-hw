using System;
//Program 1 of 4 - Youtube Videos
//Jeremy Untch


//This is the actual Program class, in this part I stored all of the information about the videos and their comments
class Program {
    static void Main(string[] args) {
        // Create 3-4 videos and add comments to them
        List<Video> videos = new List<Video>();

        //Video and comments 1
        Video video1 = new Video("Top 10 Colleges in the United States!", "Chris Hansen", 120);
        video1.AddComment(new Comment("BobTheBuilder142", "Very educational video!"));
        video1.AddComment(new Comment("Username223", "Change number 5 with number 1 and this is a great list!"));

        //Video and comments 2
        Video video2 = new Video("General Conference, October 2024 Saturday Session", "The Church of Jesus Christ of Latter-day Saints", 180);
        video2.AddComment(new Comment("ElderKnowItAll3", "Very inspirational, I learned a lot."));
        video2.AddComment(new Comment("Missy9229", "I went through a whole bag of popcorn while watching this! Very good session."));

        //Video and comments 3
        Video video3 = new Video("How to make amazing pizza", "Gordon Ramsey", 120);
        video3.AddComment(new Comment("BillyBob2", "Great video, but I still think pineapple is a must on pizza."));
        video3.AddComment(new Comment("Charlie77", "Anyone that is commenting that pineapple is a must is insane!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // This is where the information will be displayed.
        foreach (var video in videos) {
            video.DisplayDetails();
            Console.WriteLine();
        }
    }
}