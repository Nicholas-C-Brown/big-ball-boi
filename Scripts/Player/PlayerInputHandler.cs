using BigBallBoi.Scripts.Input;
using Godot;

namespace BigBallBoiGame.Scripts.Player
{

    public partial class PlayerInputHandler : Node
    {

        public float GetHorizontalMovementDirection()
        {
            return Input.GetAxis(Actions.MOVE_LEFT_ACTION, Actions.MOVE_RIGHT_ACTION);
        }

        public bool WantsToReel()
        {
            return Input.IsActionPressed(Actions.REEL_UP_ACTION) || Input.IsActionPressed(Actions.REEL_DOWN_ACTION);
        }

        public float GetVerticalReelingDirection()
        {
            return Input.GetAxis(Actions.REEL_DOWN_ACTION, Actions.REEL_UP_ACTION);
        }

        public bool WantsToJump()
        {
            return Input.IsActionJustPressed(Actions.JUMP_ACTION);
        }

    }

}
