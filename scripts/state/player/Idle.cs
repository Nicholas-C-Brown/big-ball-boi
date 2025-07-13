using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates {

    public partial class Idle : PlayerState
    {
    

        [Export] private State<Player> moveState;
        [Export] private State<Player> jumpState;
        [Export] private State<Player> fallState;

        public override State<Player>? ProcessInput(InputEvent input)
        {
            if (Parent.MovementComponent.WantsToJump())
            {
                return jumpState;
            }

            return null;
        }

        public override State<Player>? ProcessPhysics(float delta)
        {

            ApplyDeceleration(delta);

            //Handle this in the physics process to avoid a bug where
            //the movement input event is consumed before the unhandled input call
            if (Parent.MovementComponent.GetMovement() != 0)
            {
                return moveState;
            }

            Parent.MoveAndSlide();

            if (!Parent.IsOnFloor())
            {
                return fallState;
            }

            return null;
        }

    }

}
