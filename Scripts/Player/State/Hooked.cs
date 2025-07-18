using Godot;

namespace BigBallBoiGame.Scripts.Player.State {

    /// <summary>
    /// Represents the state when the player is swinging from the grappling hook.
    /// <para/>
    /// This state should only be entered when the grappling hook `OnAttached` action is triggered
    /// </summary>
    public partial class Hooked : PlayerState
    {

        [Export] PlayerState reelState;

        public override void Enter()
        {

            Vector2 hookPosition = Parent.GrapplingHook.HookPoint.GlobalPosition;
            Parent.GrapplingHook.PinJoint.GlobalPosition = hookPosition;

            Parent.GrapplingHook.PinJoint.NodeA = Parent.GrapplingHook.HookBody.GetPath();
            Parent.GrapplingHook.PinJoint.NodeB = Parent.GetPath();
            Parent.LockRotation = false;

        }

        public override void Exit()
        {
            Parent.GrapplingHook.PinJoint.NodeA = new NodePath("");
            Parent.GrapplingHook.PinJoint.NodeB = new NodePath("");

            Parent.LockRotation = true;
        }

        public override PlayerState? ProcessPhysics(float delta)
        {

            ApplyHookedMovement();
            HandleSpriteFlip();

            return null;

        }

        public override PlayerState? ProcessInput(InputEvent input)
        {
            if(Parent.InputHandler.WantsToReel())
            {
                return reelState;
            }

            return null;
        }

        private void ApplyHookedMovement()
        {
            float movement = Parent.InputHandler.GetHorizontalMovementDirection() * Parent.Stats.MovementForce;

            //Calculates the vector orthogonal to the direction from the player to the grappling hook pin joint
            var directionToHookPoint = (Parent.GrapplingHook.PinJoint.GlobalPosition - Parent.GlobalPosition).Normalized();
            var radians = Mathf.DegToRad(90);
            var orthogonalVector = directionToHookPoint.Rotated(radians);

            Parent.ApplyCentralForce(orthogonalVector * movement);
        }

        
    }
}
