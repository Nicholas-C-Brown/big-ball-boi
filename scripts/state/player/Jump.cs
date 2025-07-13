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
            Parent.Velocity = new Vector2(Parent.Velocity.X, Parent.MovementComponent.GetJumpStrength());
        }

        public override State<Player>? ProcessPhysics(float delta)
        {
            ApplyGravity(delta);
            ApplyMovement(delta);
            HandleSpriteFlip();

            Parent.MoveAndSlide();

            if (Parent.Velocity.Y > 0)
            {
                return fallState;
            }

            if (Parent.IsOnFloor())
            {
                return Parent.Velocity.X == 0 ? idleState : moveState;
            }

            return null;

        }

    }

}
