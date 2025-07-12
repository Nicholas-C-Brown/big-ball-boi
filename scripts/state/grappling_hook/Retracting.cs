using Godot;
using System;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Retracting : State
    {

        [Export] State aimState;

        [Export] private float retractSpeed = 5;

        private GrapplingHook parent;

        private Vector2 returnPosition;

        public override void Initialize()
        {
            parent = ComponentProvider.GetParentComponent<GrapplingHook>();
        }

        public override State? ProcessPhysics(float delta)
        {
            parent.HookPoint.Position += Vector2.Left * retractSpeed;
            parent.HookLine.Points = [parent.Position, parent.HookPoint.Position];

            if (parent.HookPoint.Position.Length() <= parent.AimDistance)
            {
                return aimState;
            }

            return null;
        }
    }
}