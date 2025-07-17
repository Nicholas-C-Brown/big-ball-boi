using BigBallBoiGame.State;
using Godot;

namespace BigBallBoiGame.Scripts.Player.State
{
    public partial class PlayerStateMachine : StateMachine<PlayerNode>
    {

        [Export] private PlayerState hookedState;
        [Export] private PlayerState fallingState;

        public void OnHookAttached()
        {
            ChangeState(hookedState);
        }  
        
        public void OnHookDetacted()
        {
            ChangeState(fallingState);
        }
    }
}
