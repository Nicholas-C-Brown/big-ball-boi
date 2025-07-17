using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Jump : PlayerState
    {

        [Export] private PlayerState idleState;
        [Export] private PlayerState moveState;
        [Export] private PlayerState fallState;

        public override void Enter()
        {
            base.Enter();

            Parent.ApplyCentralImpulse(new Vector2(0, Parent.MovementComponent.GetJumpStrength()));
        }

        public override PlayerState? ProcessPhysics(float delta)
        {
            ApplyMovement();
            HandleSpriteFlip();

            if (Parent.LinearVelocity.Y > 0)
            {
                return fallState;
            }

            if (Parent.IsOnFloor())
            {
                return Parent.LinearVelocity.X == 0 ? idleState : moveState;
            }

            return null;

        }

    }

}
