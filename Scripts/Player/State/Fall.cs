using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Fall : PlayerState
    {

        [Export] private PlayerState idleState;
        [Export] private PlayerState moveState;

        public override PlayerState? ProcessPhysics(float delta)
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
