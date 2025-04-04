// This is the core concept of command pattern,
// The idea here is that we encapsulate the actions of our game
// Imagine anything that a player can do in a turn base, for example
// well, anything that he can do we call store as an action
// move, attack, rotate, draw, anything...
// As long as the actions (Command) have a common Execute (OR any name you prefer)
// method, we are good to go.

public interface ITurnCommand
{
    public string Name { get; set; }
    void Execute();
    void Undo();
}

// Undo is not necessary!
// If your need is only to store commands and play it
// latter, you can avoid the Undo.