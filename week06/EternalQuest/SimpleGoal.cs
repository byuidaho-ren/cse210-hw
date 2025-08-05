/*

Date: August 5, 2025

SimpleGoal is a goal that can be done only once.
When completed, it awards _points exactly one time.
It tracks completion status with a boolean _isComplete.
Overrides methods from the base Goal to implement its unique behavior.
Supports saving and loading its state including whether it’s already completed.

Purpose: Represents a simple, one-time goal that can be completed only once.
Once completed, it awards points only once and then stays completed.

*/

public class SimpleGoal : Goal
{
    // Tracks whether this goal has been completed
    private bool _isComplete;

    // Constructor initializing the SimpleGoal with name, description, and points
    // Calls the base Goal constructor for shared fields, and sets completion to false
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false; // Goal starts as incomplete
    }

    // Called when the user records progress on the goal (completing it)
    public override int RecordEvent()
    {
        if (!_isComplete)   // If not already completed
        {
            _isComplete = true;   // Mark as completed
            return _points;       // Award points once
        }
        return 0; // If already completed, no points awarded
    }

    // Returns whether the goal has been completed
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Returns a string representation for saving/loading or displaying the goal
    // Format: SimpleGoal:Name|Description|Points|IsComplete
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}
