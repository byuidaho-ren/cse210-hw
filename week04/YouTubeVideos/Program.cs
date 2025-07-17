// Program written on July 17, 2025

using System;                       // Provides basic system functionalities like Console and DateTime
using System.Collections.Generic;   // Provides generic collections like List<T>

/// <summary>
/// Represents a video with a title, length, author, and a collection of comments.
/// </summary>
public class Video
{
    // Title of the video
    public string Title { get; set; }
    
    // Length of the video in seconds
    public int Length { get; set; }
    
    // Author or creator of the video
    public string Author { get; set; }

    // Private list to store comments associated with this video
    private List<Comment> _comments;

    /// <summary>
    /// Constructor to initialize a Video object with title, length, and author.
    /// Also initializes the comment list as empty.
    /// </summary>
    public Video(string title, int length, string author)
    {
        Title = title;          // Set the video title
        Length = length;        // Set the length in seconds
        Author = author;        // Set the author/channel name
        _comments = new List<Comment>();  // Initialize empty comments list
    }

    /// <summary>
    /// Adds a Comment object to this video's comment list.
    /// </summary>
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);  // Add the comment to the internal list
    }

    /// <summary>
    /// Returns the number of comments on this video.
    /// </summary>
    public int GetNumberOfComments()
    {
        return _comments.Count;  // Return count of comments stored
    }

    /// <summary>
    /// Provides a read-only list of comments for external use.
    /// </summary>
    public IReadOnlyList<Comment> GetComments()
    {
        return _comments.AsReadOnly();  // Return read-only wrapper around comments list
    }
}

/// <summary>
/// Represents a comment made by a viewer on a video.
/// Stores the commenter's name and the comment text.
/// </summary>
public class Comment
{
    // Name of the person who made the comment
    public string CommenterName { get; set; }
    
    // The actual text of the comment
    public string Text { get; set; }

    /// <summary>
    /// Constructor to initialize a Comment object with commenter name and comment text.
    /// </summary>
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;  // Set the commenter's name
        Text = text;                    // Set the comment text
    }
}

/// <summary>
/// Program entry point class.
/// Creates videos and comments, then outputs all video info with comments.
/// </summary>
class Program
{
    /// <summary>
    /// Main method - starting point of the program execution.
    /// </summary>
    static void Main(string[] args)
    {
        // Create a list to hold Video objects
        List<Video> videos = new List<Video>();

        // Create first video and add 3 comments
        Video video1 = new Video("How to Cook Pasta", 540, "Cooking Channel");
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can't wait to try this."));
        videos.Add(video1);  // Add video1 to the list

        // Create second video and add 3 comments
        Video video2 = new Video("Top 10 Programming Tips", 720, "Dev Guru");
        video2.AddComment(new Comment("Dana", "Awesome tips."));
        video2.AddComment(new Comment("Evan", "Really useful for beginners."));
        video2.AddComment(new Comment("Faith", "Love your channel!"));
        videos.Add(video2);  // Add video2 to the list

        // Create third video and add 3 comments
        Video video3 = new Video("Travel Vlog: Japan", 900, "Wanderlust");
        video3.AddComment(new Comment("George", "Beautiful scenery!"));
        video3.AddComment(new Comment("Hannah", "Japan is on my bucket list."));
        video3.AddComment(new Comment("Ian", "Great video quality."));
        videos.Add(video3);  // Add video3 to the list

        // Iterate through all videos to display their details and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");                     // Print video title
            Console.WriteLine($"Author: {video.Author}");                   // Print video author
            Console.WriteLine($"Length: {video.Length} seconds");           // Print video length
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");  // Print comment count

            Console.WriteLine("Comments:");                                 // Header for comments
            foreach (var comment in video.GetComments())
            {
                // Print each commenter's name and their comment text
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();  // Blank line for readability between videos
        }
    }
}
