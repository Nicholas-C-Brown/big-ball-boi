using Godot;
using Godot.Collections;
using System;
using System.Linq;

namespace BigBallBoiGame.Scripts.GrapplingHook.State
{

    public partial class Extending : GrapplingHookState
    {

        [Export] GrapplingHookState attachedState;
        [Export] GrapplingHookState retractState;

        [Export] private float hookDistance = 300;
        [Export] private float extendSpeed = 5;

        private Vector2 targetPosition;

        public override void Enter()
        {
            CalculateTargetPosition();
        }

        public override GrapplingHookState? ProcessFrame(float delta)
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

        public override GrapplingHookState? ProcessInput(InputEvent input)
        {
            if(Parent.InputHandler.WantsToRetractHook())
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
            return overlappingBodies.FirstOrDefault(b => b.GetGroups().Contains("Hookable")) != null;
        }


    }

}
