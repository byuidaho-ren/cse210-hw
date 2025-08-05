using System;
using System.Collections.Generic;
using System.IO;

/*

Date: August 5, 2025
GoalManager is the central class that manages the user's goals and score.

It handles the menu system, allowing the user to:

Create new goals of different types.
List all current goals.
Save goals and score to a file.
Load goals and score from a file.
Record progress on existing goals and update the score.

It uses the Goal base class and its subclasses (SimpleGoal, EternalGoal, ChecklistGoal) to represent different types of goals.
File saving/loading relies on a simple string serialization format and requires matching the string format of each goal type.
The user interacts with the program via the console input/output.

Purpose: Manages a collection of goals and user interaction to create, save, load, list, and record progress on goals.
Acts as the main controller of the goal-tracking application.

*/

public class GoalManager
{
    // List to hold all goals created by the user
    private List<Goal> _goals = new List<Goal>();

    // Tracks the total score (points earned by completing goals)
    private int _score = 0;

    // Entry point method for running the main program loop and displaying menu options
    public void Start()
    {
        while (true) // Infinite loop until user chooses to quit
        {
            Console.Clear();       // Clear the console for a clean UI
            DisplayPlayerInfo();   // Show current score to the user

            // Display the menu options
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select an option: ");
            string input = Console.ReadLine(); // Read user's menu choice

            // Execute the selected option
            switch (input)
            {
                case "1":
                    CreateGoal();       // Create a new goal
                    break;
                case "2":
                    ListGoalDetails();  // Display all goals with details
                    break;
                case "3":
                    SaveGoals("goals.txt"); // Save goals to file
                    break;
                case "4":
                    LoadGoals("goals.txt"); // Load goals from file
                    break;
                case "5":
                    RecordEvent();      // Record completion of a goal event
                    break;
                case "6":
                    return;             // Exit the program loop (quit)
                default:
                    // Handle invalid menu input
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // Displays the player's current score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}\n");
    }

    // Lists the goals by their details (calls GetDetailsString on each goal)
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            // Shows the goal index + 1, and the detailed status string
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Lists goals and waits for the user to press Enter before returning to menu
    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        ListGoalNames();
        Console.WriteLine("\nPress Enter to return to menu.");
        Console.ReadLine();
    }

    // Prompts the user to create a new goal by specifying type and details
    public void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        // Get common goal properties from user input
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        // Create appropriate goal object based on user's choice
        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
        }

        // Add the new goal to the list if it was created successfully
        if (goal != null)
        {
            _goals.Add(goal);
        }
    }

    // Records the completion of a goal event by the user
    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames(); // Show list of goals with numbers

        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1; // Convert user input to zero-based index

        // Check if input index is valid
        if (index >= 0 && index < _goals.Count)
        {
            // Call RecordEvent on selected goal and add earned points to total score
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
        else
        {
            // Handle invalid goal number
            Console.WriteLine("Invalid goal number.");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Saves the current score and all goals to a text file
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score); // Save score on first line
            foreach (var goal in _goals)
            {
                // Save each goal's string representation on separate lines
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved. Press Enter to continue...");
        Console.ReadLine();
    }

    // Loads score and goals from a text file
    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear(); // Clear existing goals before loading new ones
        string[] lines = File.ReadAllLines(filename);

        // First line is the saved score
        _score = int.Parse(lines[0]);

        // Iterate over each saved goal line starting from line 1
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':'); // Split to separate goal type from data
            string type = parts[0];                // Get goal type (e.g., "SimpleGoal")
            string[] data = parts[1].Split('|');  // Split data fields

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]))
                    {
                        // Note: If SimpleGoal had progress data, loading would be more complex
                    });
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    // Data format: Name|Description|Points|Bonus|Target|AmountCompleted
                    ChecklistGoal cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]));
                    // Simulate the amount of completions recorded so far
                    for (int j = 0; j < int.Parse(data[5]); j++)
                        cg.RecordEvent();
                    _goals.Add(cg);
                    break;
            }
        }
        Console.WriteLine("Goals loaded. Press Enter to continue...");
        Console.ReadLine();
    }
}
