using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Jump : PlayerState
    {

        [Export] private State<Player> idleState;
        [Export] private State<Player> moveState;
        [Export] private State<Player> fallState;

        public override void Enter()
        {
            base.Enter();

            Parent.ApplyCentralImpulse(new Vector2(0, Parent.MovementComponent.GetJumpStrength()));
        }

        public override State<Player>? ProcessPhysics(float delta)
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
