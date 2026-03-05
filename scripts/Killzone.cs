using Godot;
using System;

public partial class Killzone : Area2D
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }

    public void _on_body_entered(Node2D body)
    {
        GD.Print("Player entered killzone");
        Engine.TimeScale = 0.5f; // Slow down time for dramatic effect
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree(); // Disable player's collision
        timer.Start();
    }

    public void _on_timer_timeout()
    {
        GetTree().ReloadCurrentScene();
        Engine.TimeScale = 1f; // Reset time scale to normal
    }
}
