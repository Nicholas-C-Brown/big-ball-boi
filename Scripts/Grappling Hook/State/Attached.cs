using Godot;

namespace BigBallBoiGame.Scripts.GrapplingHook.State
{

    public partial class Attached : GrapplingHookState
    {

        [Export] private GrapplingHookState retractState;

        private Vector2 hookedPosition;

        public override void Enter()
        {
            Parent.HookAttached?.Invoke();
            hookedPosition = Parent.HookPoint.GlobalPosition;
    
        }

        public override void Exit()
        {
            Parent.HookDetached?.Invoke();
        }

        public override GrapplingHookState? ProcessFrame(float delta)
        {
            Parent.LookAt(hookedPosition);
            Parent.HookPoint.GlobalPosition = hookedPosition;

            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            return null;
        }

        public override GrapplingHookState? ProcessInput(InputEvent input)
        {

            if (Input.IsActionJustReleased("hook"))
            {
                return retractState;
            }

            return null;
        }


    }

}


