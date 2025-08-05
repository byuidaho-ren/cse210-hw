/*

 Date: August 5, 2025

ChecklistGoal is a specialized goal that requires multiple completions.
It tracks how many times it has been completed (_amountCompleted).
When the number of completions reaches _target, it is marked complete and grants a bonus.
It inherits from a Goal base class (not shown), likely sharing common fields like _shortName, _description, and _points.

Purpose: The ChecklistGoal class represents a specific type of goal in a goal-tracking system.
It extends the base class 'Goal' and adds functionality for goals that must be completed multiple times 
(like "Exercise 5 times this week") before being considered complete.

*/ 

public class ChecklistGoal : Goal
{
    // Private field to track how many times the goal has been completed so far
    private int _amountCompleted;

    // Private field to store the target number of times the goal must be completed
    private int _target;

    // Private field to store the bonus points awarded when the goal is fully completed
    private int _bonus;

    // Constructor to initialize the ChecklistGoal object
    // Parameters:
    // - name: the short name of the goal
    // - description: a brief description of the goal
    // - points: how many points are awarded for each completion
    // - target: how many times the goal must be completed to finish
    // - bonus: bonus points awarded when the target is met
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points) // Calls the base class constructor to initialize shared fields
    {
        _amountCompleted = 0;  // Starts with zero completions
        _target = target;      // Sets the required number of completions
        _bonus = bonus;        // Sets the bonus awarded on final completion
    }

    // Overrides the RecordEvent method from the base Goal class
    // Called when the user completes one instance of the goal
    // Returns:
    // - points for each completion
    // - bonus + points if this completion finishes the goal
    // - 0 if the goal is already complete
    public override int RecordEvent()
    {
        if (_amountCompleted < _target) // Only record if the goal is not yet complete
        {
            _amountCompleted++; // Increment the number of completions

            if (_amountCompleted == _target) // If this is the final completion
            {
                return _points + _bonus; // Return base points plus bonus
            }

            return _points; // Return base points for this completion
        }

        return 0; // No points if goal already completed
    }

    // Overrides the IsComplete method from the base Goal class
    // Returns true if the number of completions has reached or exceeded the target
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Overrides GetDetailsString to provide a human-readable description of the goal status
    // Format: [ ] or [X] Goal Name (Description) -- Completed: x/y
    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed: {_amountCompleted}/{_target}";
    }

    // Overrides GetStringRepresentation to serialize the goal to a string
    // Used for saving/loading data to/from storage
    // Format: ChecklistGoal:Name|Description|Points|Bonus|Target|CompletedAmount
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}
