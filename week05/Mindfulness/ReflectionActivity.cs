using System; // Imports the System namespace to access essential types like DateTime, Console, and Random.
using System.Collections.Generic; // Imports the Collections.Generic namespace to use types like List<T> for storing data.
using System.Linq; // Imports the LINQ namespace, though not used in this particular class.
using System.Threading; // Imports the Threading namespace for pausing the program using `Thread.Sleep`.


/*

Date: 2025-07-29 (Today's Date)
This class defines a "Reflection" activity that prompts the user to reflect on meaningful experiences in their life and answers specific questions to help them understand their strengths and resilience.
Constructor (ReflectionActivity):

This constructor calls the base class constructor with specific values for the activity's name ("Reflection") and description. It provides context for the activity, explaining that the purpose is to reflect on personal strength and resilience.

RunActivity Method:

Console.Clear(): Clears the console screen to start the activity with a clean slate.

StartActivity(): This method, inherited from the base class, displays the activity name, description, and asks the user for the duration in seconds.

Random Selection of Prompts and Questions:

A random prompt is selected from the list of prompts to encourage the user to reflect on a meaningful past experience.

Then, the program selects random questions from the questions list. These questions are designed to help the user dive deeper into their reflection on the selected experience.

Pauses:

The program pauses for 3 seconds after displaying the prompt (Pause(3)), giving the user time to read and reflect on it.

Each question is followed by a 5-second pause (Pause(5)) to allow time for thought before moving on to the next question.

End of Activity:

The activity runs until the user-defined duration has passed. Once the time is up, the program calls EndActivity() to end the session, provide feedback, and display a summary.

Pause(int seconds):

A helper method that pauses the program for the specified number of seconds. It is used here to give the user time to reflect after each prompt and question.

The program clears the console and starts the activity.

It selects and displays a random prompt for the user to reflect on.

After the user has a few seconds to think about the prompt, the program proceeds to ask several reflective questions, with pauses between each one.

The activity continues until the user-defined duration has passed.

Once the activity ends, the program displays a completion message and ends the session.

Additional Notes:
Randomization: The use of Random ensures that each session of the ReflectionActivity will be unique, as different prompts and questions are selected each time.

Reflection Time: The pauses between each prompt and question help to provide the user with enough time to reflect meaningfully on their experiences.


*/


public class ReflectionActivity : Activity // Defines the class "ReflectionActivity", which inherits from the abstract class "Activity".
{
    // A static list of prompts to inspire deep reflection on past experiences.
    private static readonly List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.", // Prompt 1
        "Think of a time when you did something really difficult.", // Prompt 2
        "Think of a time when you helped someone in need.", // Prompt 3
        "Think of a time when you did something truly selfless." // Prompt 4
    };

    // A static list of reflective questions that will be asked after the prompt to encourage deeper thought.
    private static readonly List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?", // Question 1
        "Have you ever done anything like this before?", // Question 2
        "How did you get started?", // Question 3
        "How did you feel when it was complete?", // Question 4
        "What made this time different than other times when you were not as successful?", // Question 5
        "What is your favorite thing about this experience?", // Question 6
        "What could you learn from this experience that applies to other situations?", // Question 7
        "What did you learn about yourself through this experience?", // Question 8
        "How can you keep this experience in mind in the future?" // Question 9
    };

    // Constructor for the ReflectionActivity class. Initializes the activity's name and description by calling the base constructor.
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    // Implementation of the abstract RunActivity() method, which is specific to the "Reflection" activity.
    public override void RunActivity()
    {
        Console.Clear(); // Clears the console to ensure a fresh start.
        StartActivity(); // Calls the StartActivity method from the base class to begin the activity (e.g., display the name, description, and prompt for duration).

        Random rand = new Random(); // Creates a new instance of the Random class to generate random numbers for selecting prompts and questions.

        // Selects a random prompt from the list of prompts.
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt); // Displays the randomly selected prompt on the screen.

        Pause(3); // Pauses for 3 seconds to give the user time to reflect on the prompt.

        DateTime endTime = DateTime.Now.AddSeconds(_duration); // Calculates the end time by adding the duration (in seconds) to the current time.

        // While the current time is less than the end time, continue asking the user reflection questions.
        while (DateTime.Now < endTime)
        {
            // Selects a random question from the list of questions.
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question); // Displays the randomly selected reflection question.
            Pause(5);  // Pauses for 5 seconds to allow the user time to think and reflect on the question.
        }

        EndActivity(); // Calls the EndActivity method from the base class to finish the activity and display a summary.
    }
}
