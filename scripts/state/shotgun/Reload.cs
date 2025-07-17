using BigBallBoiGame;
using BigBallBoiGame.State;
using BigBallBoiGame.State.ShotgunStates;
using Godot;
using System;

public partial class Reload : ShotgunState
{

    [Export] ShotgunState idleState;

    private float reloadTimer;

    public override void Enter()
    {
        //Create bullets
        GD.Print("Reloading");

        Parent.Reload();
        reloadTimer = Parent.GunComponent.GetReloadTime();

    }

    public override ShotgunState? ProcessFrame(float delta)
    {
        reloadTimer -= delta;

        if (reloadTimer < 0)
        {
            return idleState;
        }

        return null;
    }

    

}
