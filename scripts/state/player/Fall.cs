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
            ApplyGravity(delta);
            ApplyMovement(delta);
            HandleSpriteFlip();

            Parent.MoveAndSlide();

            if (Parent.IsOnFloor())
            {
                return Parent.Velocity.X == 0 ? idleState : moveState;
            }

            return null;
        }

    }

}
