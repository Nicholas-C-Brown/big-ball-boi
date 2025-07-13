using BigBallBoiGame;
using BigBallBoiGame.State;
using BigBallBoiGame.State.PlayerStates;
using Godot;
using System;

public partial class Hooked : PlayerState
{

    private Vector2 rotatePoint;
    private float hookLength;

    public override void Enter()
    {
        rotatePoint = Parent.GrapplingHook.HookPoint.GlobalPosition;

        Vector2 direction = Parent.GlobalPosition - rotatePoint;
        hookLength = direction.Length();
    }

    public override State<Player>? ProcessPhysics(float delta)
    {

        Vector2 direction = Parent.GlobalPosition - rotatePoint;
        float distance = direction.Length();

        if (distance > hookLength) {
            direction = direction.Normalized() * hookLength;
            Parent.GlobalPosition = rotatePoint + direction;
        }

        return null;
    }

}
