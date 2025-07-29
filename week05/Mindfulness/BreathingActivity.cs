using System; // Imports the System namespace, which includes fundamental types like DateTime and Console.
using System.Threading; // Imports the Threading namespace to use Thread.Sleep for pausing execution.

/*

Date: 2025-07-29 (Today's Date)
This class defines a "Breathing" activity, which walks the user through a timed breathing exercise to help with relaxation.

BreathingActivity Constructor:

The constructor is calling the Activity class's constructor with the name "Breathing" and a description.

This initializes the name and description properties for this particular activity.

RunActivity Method:

Console.Clear() clears the screen to make the activity look fresh when it starts.

StartActivity() from the base class is called to show a welcome message, description, and prompt for the duration.

DateTime endTime = DateTime.Now.AddSeconds(_duration); calculates the endTime by adding the entered duration (in seconds) to the current time (DateTime.Now).

The while loop keeps running as long as the current time is less than the endTime. During this time, it prompts the user to "Breathe in..." and "Breathe out...", alternating between the two actions.

Pause(4) is called to create a 4-second pause for each breathing cycle. The program simulates breathing by pausing and displaying each instruction in sequence.

Once the duration has passed, EndActivity() is called to display a completion message and summarize the activity.

Pause(int seconds):

A method from the Activity class that pauses for the specified number of seconds (in this case, 4 seconds). This is used to create the timing for breathing in and out.

The program starts and clears the console.

It asks the user for the duration of the activity (in seconds).

The breathing cycle begins, alternating between "Breathe in..." and "Breathe out..." for the specified duration.

Once the activity is complete, it shows a message like "Great job! You've completed the activity."

*/

public class BreathingActivity : Activity // Defines the class "BreathingActivity", which inherits from the abstract base class "Activity".
{
    // Constructor for the BreathingActivity class.
    // Calls the base class constructor to set the activity's name and description.
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    // Implementation of the abstract RunActivity() method, specific to the "Breathing" activity.
    public override void RunActivity()
    {
        Console.Clear(); // Clears the console to make the output clean and readable.
        StartActivity(); // Calls the StartActivity() method from the base class to begin the activity and gather user input (e.g., duration).

        DateTime endTime = DateTime.Now.AddSeconds(_duration); // Calculates the end time by adding the duration (in seconds) to the current time.

        // Runs the breathing exercise until the current time reaches the calculated end time.
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in..."); // Instructs the user to breathe in.
            Pause(4);  // Pauses for 4 seconds to simulate the "Breathe in" duration.

            Console.WriteLine("Breathe out..."); // Instructs the user to breathe out.
            Pause(4);  // Pauses for 4 seconds to simulate the "Breathe out" duration.
        }

        EndActivity(); // Calls the EndActivity() method from the base class to finish the activity and display a summary (e.g., duration).
    }
}
