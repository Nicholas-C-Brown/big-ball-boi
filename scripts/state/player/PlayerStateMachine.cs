using Godot;

namespace BigBallBoiGame.State.PlayerStates
{
    public partial class PlayerStateMachine : StateMachine<Player>
    {

        [Export] private State<Player> hookedState;
        [Export] private State<Player> fallingState;

        public void AttachHook(bool hooked)
        {
            if (hooked)
            {
                ChangeState(hookedState);
            }
            else
            {
                ChangeState(fallingState);
            }
        }   
    }
}
