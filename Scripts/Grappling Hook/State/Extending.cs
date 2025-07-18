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

        private Vector2 targetPosition;

        public override void Enter()
        {
            CalculateTargetPosition();
        }

        public override GrapplingHookState? ProcessFrame(float delta)
        {

            Parent.LookAt(targetPosition);
            Parent.HookPoint.Position += Vector2.Right * Parent.Stats.ExtendSpeed;
            Parent.HookLine.Points = [Parent.Position, Parent.HookPoint.Position];

            if(Parent.HookPoint.HasOverlappingBodies())
            {
                return IsHooked() ? attachedState : retractState;
            }

            if (Parent.HookPoint.Position.Length() >= Parent.Stats.HookLength)
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
            targetPosition = Parent.GlobalPosition + (aimDirection * Parent.Stats.HookLength);
        }

        private bool IsHooked()
        {
            Array<Node2D> overlappingBodies = Parent.HookPoint.GetOverlappingBodies();
            return overlappingBodies.FirstOrDefault(b => b.GetGroups().Contains("Hookable")) != null;
        }


    }

}
