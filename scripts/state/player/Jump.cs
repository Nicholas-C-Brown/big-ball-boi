using Godot;
using System;

public partial class Jump : PlayerState
{

    [Export] private State idleState;
    [Export] private State moveState;
    [Export] private State fallState;

    public override void Enter()
    {
        base.Enter();
        _parent.Velocity = new Vector2(_parent.Velocity.X, _movementComponent.GetJumpStrength());
    }

    public override State? ProcessPhysics(float delta)
    {
        ApplyGravity(delta);
        ApplyMovement(delta);
        HandleSpriteFlip();

        _parent.MoveAndSlide();

        if (_parent.Velocity.Y > 0)
        {
            return fallState;
        }

        if (_parent.IsOnFloor())
        {
            return _parent.Velocity.X == 0 ? idleState : moveState;
        }

        return null;

    }

}
