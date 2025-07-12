using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Hooked : State
    {

        [Export] private State retractState;

        private Vector2 hookedPosition;

        private GrapplingHook parent;

        public override void Initialize()
        {
            parent = ComponentProvider.GetParentComponent<GrapplingHook>();
        }

        public override void Enter()
        {
            hookedPosition = parent.HookPoint.GlobalPosition;
        }

        public override State? ProcessPhysics(float delta)
        {
            parent.LookAt(hookedPosition);
            parent.HookPoint.GlobalPosition = hookedPosition;

            parent.HookLine.Points = [parent.Position, parent.HookPoint.Position];

            return null;
        }

        public override State? ProcessInput(InputEvent input)
        {
            if (Input.IsActionJustReleased("hook"))
            {
                return retractState;
            }

            return null;
        }


    }

}


