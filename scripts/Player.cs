using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 200.0f;
    public const float JumpVelocity = -350.0f;
    private AnimatedSprite2D Sprite;

    public override void _Ready()
    {
        base._Ready();
        Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        // Get the input directions  (-1, 0, or 1)
        float direction = Input.GetAxis("move_left", "move_right");

        // flip the sprite
        if (direction > 0)
        {
            Sprite.FlipH = false;
        }
        else if (direction < 0)
        {
            Sprite.FlipH = true;
        }

        // play animations
        if (IsOnFloor())
        {
            if (direction == 0)
            {
                Sprite.Play("idle");
            }
            else if (direction == 1 || direction == -1)
            {
                Sprite.Play("run");
            }
        }
        else
        {
            Sprite.Play("jump");
        }


        // apply movement
        if (direction != 0)
        {
            velocity.X = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
