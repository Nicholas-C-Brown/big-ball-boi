using Godot;

namespace BigBallBoiGame.Scripts.GrapplingHook.State
{

    public partial class Retracting : GrapplingHookState
    {

        [Export] GrapplingHookState aimState;
  
        public override GrapplingHookState? ProcessFrame(float delta)
        {
            Vector2 lerpPosition = Parent.HookPoint.GlobalPosition.Lerp(Parent.GlobalPosition, Parent.Stats.RetractSpeed * delta);
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