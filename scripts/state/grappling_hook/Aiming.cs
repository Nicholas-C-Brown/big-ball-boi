using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Aiming : State<GrapplingHook>
    {

        [Export] private State<GrapplingHook> extendState;

        public override void Enter()
        {
            Parent.HookPoint.Position = new Vector2(Parent.AimDistance, 0);
            Parent.HookLine.Points = Array.Empty<Vector2>();
        }

        public override State<GrapplingHook>? ProcessFrame(float delta)
        {
            Vector2 mousePosition = Parent.GetGlobalMousePosition();
            Parent.LookAt(mousePosition);

            if(Input.IsActionJustPressed("hook"))
            {
                return extendState;
            }

            return null;
        }



    }

}
