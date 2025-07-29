using System; // Imports the System namespace to access basic types like Console.


/*

Date: 2025-07-29 (Today's Date)
This class defines the main user interface of the Mindfulness App, where users can choose from different mindfulness activities or exit the app.

Infinite Loop (while (true)):

The program continuously runs in a loop, presenting the user with a menu of activities. The loop will only stop when the user chooses to exit the app (option 4).

Console Interaction:

The program presents the user with a menu, allowing them to choose between three mindfulness activities (BreathingActivity, ReflectionActivity, and ListingActivity), or exit the app.

Console.Clear() clears the console screen for each new round of interaction, giving a clean interface to the user.

Console.WriteLine() and Console.Write() are used to display instructions, activity options, and prompts to the user.

User Input Handling:

string choice = Console.ReadLine(); reads the user’s input from the console (the number they input to select an activity).

The program checks the input using a switch statement to determine which activity to initiate.

If the user enters an invalid input (anything other than 1, 2, 3, or 4), the program displays "Invalid choice, please try again." and the loop continues, prompting for input again.

Activity Selection:

Depending on the user's choice:

If the user selects "1", an instance of the BreathingActivity class is created.

If the user selects "2", an instance of the ReflectionActivity class is created.

If the user selects "3", an instance of the ListingActivity class is created.

If the user selects "4", a message is displayed thanking them for using the app, and the return statement exits the Main method, ending the program.

Running the Selected Activity:

After selecting an activity, the RunActivity() method is called for the respective activity object (either BreathingActivity, ReflectionActivity, or ListingActivity).

This is where the activity logic (from the respective activity class) takes place, and the user interacts with it.

Exiting the Program:

If the user selects "4", the program thanks them for using the app and exits with return.

The user opens the app and sees the main menu with activity options.

They select an activity (e.g., "1" for Breathing Activity).

The program starts the corresponding activity by creating an instance of the appropriate class (BreathingActivity) and calling RunActivity().

Once the activity is complete, the app returns to the menu to allow the user to select another activity or exit.

If the user selects "4", the program ends with a goodbye message.

Additional Notes:
Error Handling: The program gracefully handles invalid user input by displaying a message and prompting for a correct choice again.

Infinite Loop: The app stays in the loop until the user decides to exit by selecting option "4".


*/


class Program // Defines the "Program" class, which is the entry point of the application.
{
    static void Main(string[] args) // Main method: The starting point of the application.
    {
        while (true) // Infinite loop to keep the program running until the user chooses to exit.
        {
            Console.Clear(); // Clears the console to give the user a fresh screen.
            Console.WriteLine("Welcome to the Mindfulness App!"); // Displays a welcome message.
            Console.WriteLine("Choose an activity:"); // Prompts the user to choose an activity.
            Console.WriteLine("1. Breathing Activity"); // Option 1: Breathing activity.
            Console.WriteLine("2. Reflection Activity"); // Option 2: Reflection activity.
            Console.WriteLine("3. Listing Activity"); // Option 3: Listing activity.
            Console.WriteLine("4. Exit"); // Option 4: Exit the app.
            Console.Write("Enter the number of the activity: "); // Asks the user to enter their choice.
            string choice = Console.ReadLine(); // Reads the user's input and stores it in the 'choice' variable.

            Activity activity = null; // Initializes an Activity object to null. This will hold the selected activity.

            // Switch case structure to choose which activity to run based on user input.
            switch (choice)
            {
                case "1": // If the user chooses option 1, the BreathingActivity is created.
                    activity = new BreathingActivity();
                    break;
                case "2": // If the user chooses option 2, the ReflectionActivity is created.
                    activity = new ReflectionActivity();
                    break;
                case "3": // If the user chooses option 3, the ListingActivity is created.
                    activity = new ListingActivity();
                    break;
                case "4": // If the user chooses option 4, the app displays a goodbye message and exits.
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    return; // Exits the program.
                default: // If the user enters an invalid choice, an error message is shown.
                    Console.WriteLine("Invalid choice, please try again.");
                    continue; // Goes back to the beginning of the loop to ask for input again.
            }

            // Once an activity is selected, the RunActivity method is called to start the activity.
            activity.RunActivity();
        }
    }
}
