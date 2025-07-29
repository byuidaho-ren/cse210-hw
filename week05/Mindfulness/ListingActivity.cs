using System; // Imports the System namespace for general purpose types such as DateTime, Console, and Random.
using System.Collections.Generic; // Imports the generic collections namespace to use types like List<T>.
using System.Linq; // Imports LINQ (Language Integrated Query) methods, although not used directly in this class.
using System.Threading; // Imports the Threading namespace to use Thread.Sleep for pausing execution.


/*

Date: 2025-07-29 (Today's Date)
This class defines a "Listing" activity that encourages the user to reflect on positive aspects of their life by listing items related to a random prompt.

Constructor (ListingActivity):

Calls the constructor of the base Activity class with specific values for the name ("Listing") and description. This initializes the properties in the base class.

The prompt list is statically defined with several reflective questions to guide the user’s listing.

RunActivity Method:

Clears the console (Console.Clear()).

Calls the StartActivity() method from the base class to prepare the activity by displaying the name, description, and prompting for a duration.

A random prompt is selected from the prompts list, and the prompt is displayed to the user (Console.WriteLine(prompt)).

The Pause(3) method is called to pause for 3 seconds, giving the user time to absorb the prompt.

The program then tells the user to start listing ("Start listing...").

It enters a while loop that continues as long as the current time is less than the calculated endTime (i.e., until the activity duration has passed).

Inside the loop, the program waits for the user to input items using Console.ReadLine(). If the input is not empty, it adds the item to a list called items.

After the activity duration is over, the number of items listed is printed: Console.WriteLine($"You listed {items.Count} items.");

Finally, it calls EndActivity() to finish the activity and display a completion message.

Pause(int seconds):

A method from the Activity class that pauses the program for a specified number of seconds (in this case, 3 seconds), creating a small delay between user actions.

The activity clears the console and starts by displaying a random prompt.

The user is given time to read the prompt, then they are encouraged to start listing.

The user types in their responses (e.g., names of people they appreciate or personal strengths), and the program collects these responses.

After the allotted time (based on user input), the program displays how many items the user listed and ends the activity.

Additional Notes:
Random Prompt Selection: The class randomly selects one of the predefined prompts to encourage reflection on various positive aspects of life.

User Input Handling: The program ensures that only non-empty inputs are added to the list of items, ignoring blank or empty responses.

*/

public class ListingActivity : Activity // Defines the "ListingActivity" class, inheriting from the abstract base class "Activity".
{
    // A static list of prompts used to inspire the user to list things for reflection.
    private static readonly List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?", // Prompt 1
        "What are personal strengths of yours?", // Prompt 2
        "Who are people that you have helped this week?", // Prompt 3
        "When have you felt the Holy Ghost this month?", // Prompt 4
        "Who are some of your personal heroes?" // Prompt 5
    };

    // Constructor for ListingActivity. Sets the activity's name and description by calling the base constructor.
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    // Implementation of the abstract RunActivity() method, specific to the "Listing" activity.
    public override void RunActivity()
    {
        Console.Clear(); // Clears the console to start with a fresh screen.
        StartActivity(); // Calls the StartActivity method from the base class to initialize the activity (displays name, description, duration input, etc.).

        Random rand = new Random(); // Creates a new instance of the Random class to generate random numbers.

        // Selects a random prompt from the "prompts" list.
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt); // Prints the randomly selected prompt to the console.

        Pause(3); // Pauses for 3 seconds to allow the user to read the prompt.

        Console.WriteLine("Start listing..."); // Informs the user to begin listing items.

        List<string> items = new List<string>(); // Initializes an empty list to store the user's input items.

        DateTime endTime = DateTime.Now.AddSeconds(_duration); // Sets the end time for the activity by adding the user-defined duration to the current time.

        // Loops until the current time exceeds the end time (activity duration has elapsed).
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine(); // Waits for the user to input an item and stores it in the 'item' variable.

            // If the user provides a non-empty input, add it to the "items" list.
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item); // Adds the input item to the list.
            }
        }

        // After the activity ends, prints the number of items the user listed.
        Console.WriteLine($"You listed {items.Count} items.");

        EndActivity(); // Calls the EndActivity method from the base class to conclude the activity and display a summary.
    }
}
