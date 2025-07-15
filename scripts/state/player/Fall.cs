using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Fall : PlayerState
    {

        [Export] private State<Player> idleState;
        [Export] private State<Player> moveState;

        public override State<Player>? ProcessPhysics(float delta)
        {

            RealignGlobalRotation(delta);
            ApplyMovement();
            HandleSpriteFlip();

            if (Parent.IsOnFloor())
            {
                return Parent.LinearVelocity.X == 0 ? idleState : moveState;
            }

            return null;
        }

        public override void Exit()
        {
            Parent.GlobalRotation = 0;
        }

    }

}
