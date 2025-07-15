using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Retracting : State<GrapplingHook>
    {

        [Export] State<GrapplingHook> aimState;

        [Export] private float retractSpeed = 5;
  
        public override State<GrapplingHook>? ProcessPhysics(float delta)
        {
            Vector2 lerpPosition = Parent.HookPoint.GlobalPosition.Lerp(Parent.GlobalPosition, retractSpeed * delta);
            Parent.HookPoint.GlobalPosition = lerpPosition;
            
            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            if (Parent.HookPoint.Position.Length() <= Parent.AimDistance)
            {
                return aimState;
            }

            return null;
        }
    }
}