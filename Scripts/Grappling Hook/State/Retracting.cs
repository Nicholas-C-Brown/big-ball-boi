using Godot;

namespace BigBallBoiGame.Scripts.GrapplingHook.State
{

    public partial class Retracting : GrapplingHookState
    {

        [Export] GrapplingHookState aimState;

        [Export] private float retractSpeed = 5;
  
        public override GrapplingHookState? ProcessFrame(float delta)
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