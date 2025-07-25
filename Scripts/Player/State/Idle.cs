using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State {

    public partial class Idle : PlayerState
    {
    

        [Export] private PlayerState moveState;
        [Export] private PlayerState jumpState;
        [Export] private PlayerState fallState;

        public override PlayerState? ProcessInput(InputEvent input)
        {
            if (Parent.InputHandler.WantsToJump())
            {
                return jumpState;
            }

            return null;
        }

        public override PlayerState? ProcessPhysics(float delta)
        {

            if (Parent.InputHandler.GetHorizontalMovementDirection() != 0)
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
