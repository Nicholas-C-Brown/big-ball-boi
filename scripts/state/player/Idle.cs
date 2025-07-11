using Godot;
using System;

public partial class Idle : PlayerState
{

    [Export] private State moveState;
    [Export] private State jumpState;
    [Export] private State fallState;

    public override State? ProcessInput(InputEvent input)
    {
        if(_movementComponent.WantsToJump())
        {
            return jumpState;
        }

        return null;
    } 

    public override State? ProcessPhysics(float delta)
    {
        //Handle this in the physics process to avoid a bug where
        //the movement input event is consumed before the unhandled input call
        if (_movementComponent.GetMovement() != 0)
        {
            return moveState;
        }

        _parent.MoveAndSlide();

        if (!_parent.IsOnFloor())
        {
            return fallState;
        }

        return null;
    }






}
