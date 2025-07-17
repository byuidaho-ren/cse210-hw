using System;                      // Provides basic input/output and fundamental types
using System.Collections.Generic;  // Allows use of generic collections like List<T>

// Represents a single YouTube video
public class Video
{
    // Title of the video
    public string Title { get; set; }
    
    // Duration of the video in seconds
    public int Duration { get; set; }
    
    // Number of times the video has been viewed
    public int Views { get; set; }
    
    // Name of the channel that published the video
    public string ChannelName { get; set; }

    // Constructor to initialize a new Video object
    public Video(string title, int duration, string channelName)
    {
        Title = title;
        Duration = duration;
        Views = 0;               // Initially, the video has zero views
        ChannelName = channelName;
    }

    // Simulate playing the video which increments the view count
    public void Play()
    {
        Views++;   // Increment view count by 1
        Console.WriteLine($"Playing video: {Title} from {ChannelName}");  // Display message
        Console.WriteLine($"[Timestamp: {DateTime.Now}]");                  // Display current date/time
    }

    // Display detailed info about the video
    public void GetDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine($"Views: {Views}");
        Console.WriteLine($"Channel: {ChannelName}");
        Console.WriteLine($"[Timestamp: {DateTime.Now}]");  // Display current date/time
    }
}

// Represents a YouTube channel that contains multiple videos
public class Channel
{
    // Name of the channel
    public string Name { get; set; }
    
    // List of videos associated with this channel
    public List<Video> Videos { get; private set; }

    // Constructor to initialize a new Channel object
    public Channel(string name)
    {
        Name = name;
        Videos = new List<Video>();  // Initialize the list of videos as empty
    }

    // Add a new video to the channel's collection
    public void AddVideo(Video video)
    {
        Videos.Add(video);
    }

    // Display all video titles in the channel
    public void ShowVideos()
    {
        Console.WriteLine($"Videos in channel {Name}:");
        foreach (var video in Videos)
        {
            Console.WriteLine($"- {video.Title}");
        }
        Console.WriteLine($"[Timestamp: {DateTime.Now}]");  // Display current date/time
    }
}

// Program entry point class where execution starts
class Program
{
    // Main method - the starting point of the program
    static void Main(string[] args)
    {
        // Create a new channel named "Tech Reviews"
        Channel channel = new Channel("Tech Reviews");
        
        // Create a new video associated with "Tech Reviews" channel
        Video video1 = new Video("Review of the new smartphone", 600, "Tech Reviews");
        
        // Add the video to the channel's video list
        channel.AddVideo(video1);

        // Play the video, which increments the view count and outputs a message with timestamp
        video1.Play();  
        /* Expected output:
           Playing video: Review of the new smartphone from Tech Reviews
           [Timestamp: 2025-07-17 14:23:05]
        */
        
        // Display video details with current view count and timestamp
        video1.GetDetails();
        /* Expected output:
           Title: Review of the new smartphone
           Duration: 600 seconds
           Views: 1
           Channel: Tech Reviews
           [Timestamp: 2025-07-17 14:23:05]
        */
        
        // List all videos in the "Tech Reviews" channel with timestamp
        channel.ShowVideos();
        /* Expected output:
           Videos in channel Tech Reviews:
           - Review of the new smartphone
           [Timestamp: 2025-07-17 14:23:05]
        */
    }
}
