using Godot;
using System;

public partial class Jump : State
{

    [Export] private State idleState;
    [Export] private State moveState;
    [Export] private State fallState;

    private CharacterBody2D _parent;

    public override void Initialize()
    {
        _parent = ComponentProvider.GetParentComponent<CharacterBody2D>();
    }

    public override void Enter()
    {
        base.Enter();
        _parent.Velocity = new Vector2(_parent.Velocity.X, -400f);
    }

    public override State? ProcessPhysics(float delta)
    {
        _parent.Velocity += gravity * delta;

        if (_parent.Velocity.Y > 0)
        {
            return fallState;
        }

        //Movement
        float movement = Input.GetAxis("move_left", "move_right");
        _parent.Velocity = new Vector2(movement * 100f, _parent.Velocity.Y);
        _parent.MoveAndSlide();

        if (_parent.IsOnFloor())
        {
            return movement == 0 ? idleState : moveState;
        }

        return null;

    }

}
