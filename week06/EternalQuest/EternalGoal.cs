/*

Date: August 5, 2025

EternalGoal is for tasks that repeat endlessly.
Every time it's completed, the user earns _points, but the goal is never considered complete.
It’s useful for habit-building activities that should be done regularly, without an end (e.g., "Read a book", "Take vitamins").
Inherits from the base Goal class (again assumed to contain common fields like _shortName, _description, _points).

Purpose: The EternalGoal class represents a goal that never ends — it can be completed infinite times.
This is useful for goals like "Daily meditation" or "Drink water", where each completion gives points,
but the goal itself is never marked as complete.

*/


public class EternalGoal : Goal
{
    // Constructor for EternalGoal
    // Parameters:
    // - name: the short name of the goal
    // - description: a description of the goal
    // - points: the number of points awarded for each completion
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { } // Calls the base Goal constructor to initialize shared fields

    // Overrides RecordEvent to define what happens when this goal is recorded as completed
    // Since it's eternal, it just awards the points every time with no limit
    public override int RecordEvent()
    {
        return _points; // Always award the same number of points
    }

    // Overrides IsComplete to define when the goal is considered done
    // Since this is an "eternal" goal, it's never completed
    public override bool IsComplete()
    {
        return false; // Always returns false, so it never gets marked as complete
    }

    // Overrides GetStringRepresentation to save/serialize the goal data
    // Format: EternalGoal:Name|Description|Points
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}|{_description}|{_points}";
    }
}
