using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Fall : PlayerState
    {

        [Export] private State idleState;
        [Export] private State moveState;

        public override State? ProcessPhysics(float delta)
        {
            ApplyGravity(delta);
            ApplyMovement(delta);
            HandleSpriteFlip();

            _parent.MoveAndSlide();

            if (_parent.IsOnFloor())
            {
                return _parent.Velocity.X == 0 ? idleState : moveState;
            }

            return null;
        }

    }

}
