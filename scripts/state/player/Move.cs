using Godot;
using System;

public partial class Move : State
{

    [Export] private State idleState;
    [Export] private State jumpState;
    [Export] private State fallState;

    private CharacterBody2D? _parent;

    public override void Initialize()
    {
        _parent = ComponentProvider.GetParentComponent<CharacterBody2D>();
    }

    public override State? ProcessInput(InputEvent input)
    {
        if (Input.IsActionJustPressed("jump") && _parent.IsOnFloor())
        {
            return jumpState;
        }

        return null;
    }

    public override State? ProcessPhysics(float delta)
    {
        _parent.Velocity += gravity * delta;
        _parent.MoveAndSlide();

        //Movement

        float movement = Input.GetAxis("move_left", "move_right");

        if (movement == 0)
        {
            return idleState;
        }

        _parent.Velocity = new Vector2(movement * 100f, _parent.Velocity.Y);
        _parent.MoveAndSlide();

        if (!_parent.IsOnFloor())
        {
            return fallState;
        }

        return null;
    }

}
