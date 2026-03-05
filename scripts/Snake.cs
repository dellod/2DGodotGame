using Godot;
using System;

public partial class Snake : Node2D
{
    private const float SPEED = 60f;
    private RayCast2D RayCastLeft;
    private RayCast2D RayCastRight;
    private RayCast2D RayCastDown;
    private Vector2 Direction = Vector2.Left;
    private AnimatedSprite2D Sprite;

    public override void _Ready()
    {
        base._Ready();

        // Get references to the raycasts from the scene
        RayCastLeft = GetNode<RayCast2D>("RayCastLeft");
        RayCastRight = GetNode<RayCast2D>("RayCastRight");
        RayCastDown = GetNode<RayCast2D>("RayCastDown");
 
        // get sprite 2d
        Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        // Enable them and ensure they're ready
        RayCastLeft.Enabled = true;
        RayCastRight.Enabled = true;
        RayCastDown.Enabled = true;
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Check if at the edge (no ground below in the direction of travel)
        if (!RayCastDown.IsColliding())
        {
            // At edge, turn around
            Direction = Direction == Vector2.Right ? Vector2.Left : Vector2.Right;
            Sprite.FlipH = (Direction == Vector2.Right);
            // GD.Print($"Flip H is: {Sprite.FlipH}");
        }
        Position += Direction * SPEED * (float)delta;
    }
}
