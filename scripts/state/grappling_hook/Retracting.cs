using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Retracting : State<GrapplingHook>
    {

        [Export] State<GrapplingHook> aimState;

        [Export] private float retractSpeed = 5;

        private Vector2 returnPosition;

      
        public override State<GrapplingHook>? ProcessPhysics(float delta)
        {
            Parent.HookPoint.Position += Vector2.Left * retractSpeed;
            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            if (Parent.HookPoint.Position.Length() <= Parent.AimDistance)
            {
                return aimState;
            }

            return null;
        }
    }
}