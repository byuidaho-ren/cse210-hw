using System; // Imports the System namespace for basic classes like Console.
using System.Threading; // Imports the Threading namespace for the Thread.Sleep method to pause execution.

/* 

Date: 2025-07-29 (Today's Date)

This class serves as a template for creating activities, and the abstract method RunActivity must be implemented by subclasses to define specific activity behavior.

StartActivity(): This method is responsible for welcoming the user to the activity, showing its description, asking for the duration, and initiating a brief "Get ready..." message before starting.

EndActivity(): This method is invoked when the activity is over. It provides feedback to the user, showing the total duration and displaying a "Great job!" message.

Pause(): A helper function that pauses for a specified number of seconds, printing dots (.) to simulate a countdown or time lapse.

RunActivity(): This is an abstract method, meaning that subclasses must implement this method to define the specific behavior of the activity.

*/

public abstract class Activity // Declares an abstract class named "Activity".
{
    protected string _name; // Declares a protected string variable "_name" to store the name of the activity.
    protected string _description; // Declares a protected string variable "_description" to store a description of the activity.
    protected int _duration; // Declares a protected integer variable "_duration" to store the activity's duration in seconds.

    // Constructor that initializes the name and description of the activity.
    public Activity(string name, string description)
    {
        _name = name; // Sets the value of "_name" to the passed-in value.
        _description = description; // Sets the value of "_description" to the passed-in value.
    }

    // Start the activity
    public virtual void StartActivity()
    {
        Console.Clear(); // Clears the console screen.
        Console.WriteLine($"Welcome to the {_name} activity!"); // Prints a welcome message with the name of the activity.
        Console.WriteLine(_description); // Prints the description of the activity.
        Console.Write("Please enter the duration in seconds: "); // Asks the user to input the duration of the activity.
        _duration = Convert.ToInt32(Console.ReadLine()); // Reads the input from the user, converts it to an integer, and stores it in "_duration".
        Console.WriteLine("Get ready..."); // Prints a "Get ready..." message.
        Pause(3); // Calls the Pause method for 3 seconds, simulating a countdown or preparation time.
    }

    // End the activity
    public virtual void EndActivity()
    {
        Console.WriteLine("Great job! You've completed the activity."); // Prints a completion message.
        Console.WriteLine($"Duration: {_duration} seconds."); // Prints the total duration of the activity.
        Pause(3); // Calls the Pause method for 3 seconds to display the end message.
    }

    // Helper method for pausing and showing animation
    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++) // Loops for the number of seconds passed in the argument.
        {
            Console.Write("."); // Prints a dot to represent the passage of time or a countdown.
            Thread.Sleep(1000); // Pauses the execution of the program for 1 second (1000 milliseconds).
        }
        Console.WriteLine(); // Prints a new line after the pause animation.
    }

    // Abstract method for specific activity logic that must be implemented in subclasses.
    public abstract void RunActivity();
}
