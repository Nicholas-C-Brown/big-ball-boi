using Godot;
using System;

public partial class Move : PlayerState
{

    [Export] private State idleState;
    [Export] private State jumpState;
    [Export] private State fallState;

    public override State? ProcessInput(InputEvent input)
    {
        if (_movementComponent.WantsToJump())
        {
            return jumpState;
        }

        return null;
    }

    public override State? ProcessPhysics(float delta)
    {
        
        ApplyGravity(delta);
        ApplyMovement(delta);
        
        _parent.MoveAndSlide();

        if (_parent.Velocity == Vector2.Zero)
        {
            return idleState;
        }

        if (!_parent.IsOnFloor())
        {
            return fallState;
        }

        return null;
    }

}
