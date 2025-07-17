using Godot;
using Godot.Collections;

namespace BigBallBoiGame.State.GrapplingHookStates
{

    public partial class Extending : State<GrapplingHook>
    {

        [Export] State<GrapplingHook> attachedState;
        [Export] State<GrapplingHook> retractState;

        [Export] private float hookDistance = 300;
        [Export] private float extendSpeed = 5;

        private Vector2 targetPosition;

        public override void Enter()
        {
            CalculateTargetPosition();
        }

        public override State<GrapplingHook>? ProcessFrame(float delta)
        {

            Parent.LookAt(targetPosition);
            Parent.HookPoint.Position += Vector2.Right * extendSpeed;
            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            if(Parent.HookPoint.HasOverlappingBodies())
            {
                return IsHooked() ? attachedState : retractState;
            }

            if (Parent.HookPoint.Position.Length() >= hookDistance)
            {
                return retractState;
            }

            return null;
        }

        public override State<GrapplingHook>? ProcessInput(InputEvent input)
        {
            if(Input.IsActionJustReleased("hook"))
            {
                return retractState;
            }

            return null;
        }

        private void CalculateTargetPosition()
        {
            Vector2 mousePosition = Parent.GetGlobalMousePosition();
            Vector2 aimDirection = (mousePosition - Parent.GlobalPosition).Normalized();
            targetPosition = Parent.GlobalPosition + (aimDirection * hookDistance);
        }

        private bool IsHooked()
        {

            Array<Node2D> overlappingBodies = Parent.HookPoint.GetOverlappingBodies();
            foreach (Node2D body in overlappingBodies)
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
