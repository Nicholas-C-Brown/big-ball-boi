using Godot;
using System;

public partial class Idle : State
{

    [Export] private State moveState;
    [Export] private State jumpState;
    [Export] private State fallState;

    private CharacterBody2D _parent;

    public override void Initialize()
    {
        _parent = ComponentProvider.GetParentComponent<CharacterBody2D>();
    }

    public override void Enter()
    {
        base.Enter();
        _parent.Velocity = Vector2.Zero;
    }

    public override State? ProcessInput(InputEvent input)
    {
        if(Input.GetAxis("move_left", "move_right") != 0)
        {
            return moveState;
        }
        if(Input.IsActionJustPressed("jump"))
        {
            return jumpState;
        }

        return null;
    }

    public override State? ProcessPhysics(float delta)
    {
        _parent.Velocity += gravity * delta;
        _parent.MoveAndSlide();

        if (!_parent.IsOnFloor())
        {
            return fallState;
        }

        return null;
    }






}
