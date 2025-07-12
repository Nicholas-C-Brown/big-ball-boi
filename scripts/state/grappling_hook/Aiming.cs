using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Aiming : State
    {

        [Export] private State extendState;

        private GrapplingHook parent;

        public override void Initialize()
        {
            parent = ComponentProvider.GetParent<GrapplingHook>();
        }

        public override void Enter()
        {
            parent.HookPoint.Position = new Vector2(parent.AimDistance, 0);
            parent.HookLine.Points = Array.Empty<Vector2>();
        }

        public override State? ProcessPhysics(float delta)
        {
            Vector2 mousePosition = parent.GetGlobalMousePosition();
            parent.LookAt(mousePosition);

            if(Input.IsActionJustPressed("hook"))
            {
                return extendState;
            }

            return null;
        }



    }

}
