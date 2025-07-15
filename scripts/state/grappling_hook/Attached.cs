using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Attached : State<GrapplingHook>
    {

        [Export] private State<GrapplingHook> retractState;

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

        public override State<GrapplingHook>? ProcessPhysics(float delta)
        {
            Parent.LookAt(hookedPosition);
            Parent.HookPoint.GlobalPosition = hookedPosition;

            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            return null;
        }

        public override State<GrapplingHook>? ProcessInput(InputEvent input)
        {

            if (Input.IsActionJustReleased("hook"))
            {
                return retractState;
            }

            return null;
        }


    }

}


