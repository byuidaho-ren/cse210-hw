/*

Date: August 5, 2025

Goal is an abstract base class meaning you cannot create instances of it directly.
It defines the common data fields (_shortName, _description, _points) shared by all goals.
It forces derived classes to implement key methods:

RecordEvent() — what happens when you complete the goal or part of it.
IsComplete() — whether the goal is finished.
GetStringRepresentation() — a way to serialize or display the goal's data.

Provides a default implementation of GetDetailsString() that can be overridden.
Serves as the blueprint for specialized goals like ChecklistGoal and EternalGoal.

Purpose: The abstract base class Goal defines the common structure and behavior for all types of goals.
It provides shared fields and methods, and enforces implementation of key behaviors through abstract methods.

*/

public abstract class Goal
{
    // Protected fields to store the basic information of a goal
    // Protected means accessible in this class and in derived classes
    protected string _shortName;      // Short name or title of the goal
    protected string _description;    // Description of what the goal is about
    protected int _points;            // Points awarded for completing the goal or a unit of the goal

    // Constructor to initialize a new goal with name, description, and points
    public Goal(string name, string description, int points)
    {
        _shortName = name;            // Initialize the goal's name
        _description = description;   // Initialize the description
        _points = points;             // Initialize the points value
    }

    // Abstract method to record an event of completing the goal (or a part of it)
    // Must be implemented by any subclass
    // Returns the number of points earned by recording this event
    public abstract int RecordEvent();

    // Abstract method to check if the goal is complete
    // Must be implemented by subclasses
    // Returns true if goal is complete, false otherwise
    public abstract bool IsComplete();

    // Virtual method to get a detailed string representation of the goal's status
    // Can be overridden by subclasses but has a default implementation here
    public virtual string GetDetailsString()
    {
        // Returns a string like:
        // [X] GoalName (Description) if complete
        // [ ] GoalName (Description) if not complete
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";
    }

    // Abstract method to get a string representation for saving or displaying the goal
    // Must be implemented by subclasses
    public abstract string GetStringRepresentation();
}
