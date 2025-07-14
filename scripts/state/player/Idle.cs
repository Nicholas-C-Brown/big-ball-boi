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

            if (Parent.MovementComponent.GetMovement() != 0)
            {
                return moveState;
            }

            if (!Parent.IsOnFloor())
            {
                return fallState;
            }

            return null;
        }

    }

}
