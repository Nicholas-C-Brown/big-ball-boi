using Godot;
using Godot.Collections;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Extending : State
    {

        [Export] State hookedState;
        [Export] State retractState;

        [Export] private float hookDistance = 300;
        [Export] private float extendSpeed = 5;

        private GrapplingHook parent;

        private Vector2 targetPosition;

        public override void Initialize()
        {
            parent = ComponentProvider.GetParentComponent<GrapplingHook>();
        }

        public override void Enter()
        {
            CalculateTargetPosition();
        }

        public override State? ProcessPhysics(float delta)
        {

            parent.LookAt(targetPosition);
            parent.HookPoint.Position += Vector2.Right * extendSpeed;
            parent.HookLine.Points = [parent.Position, parent.HookPoint.Position];

            if(parent.HookPoint.HasOverlappingBodies())
            {
                return IsHooked() ? hookedState : retractState;
            }

            if (parent.HookPoint.Position.Length() >= hookDistance)
            {
                return retractState;
            }

            return null;
        }

        public override State? ProcessInput(InputEvent input)
        {
            if(Input.IsActionJustReleased("hook"))
            {
                return retractState;
            }

            return null;
        }

        private void CalculateTargetPosition()
        {
            Vector2 mousePosition = parent.GetGlobalMousePosition();
            Vector2 aimDirection = (mousePosition - parent.GlobalPosition).Normalized();
            targetPosition = parent.GlobalPosition + (aimDirection * hookDistance);
        }

        private bool IsHooked()
        {
            Array<Node2D> overlappingBodies = parent.HookPoint.GetOverlappingBodies();
            foreach (Node body in overlappingBodies)
            {
                if (body.GetGroups().Contains("Hookable"))
                {
                    return true; 
                }
            }

            return false;
        }


    }

}
