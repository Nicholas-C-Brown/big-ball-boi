using Godot;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Reeling : PlayerState
    {

        [Export] public PlayerState hookedState;
        [Export] public PlayerState fallState;

        public override PlayerState? ProcessPhysics(float delta)
        {
            var directionToHookPoint = (Parent.GrapplingHookPinJoint.GlobalPosition - Parent.GlobalPosition).Normalized();

            Vector2 reelForce = Vector2.Zero;

            if (Input.IsActionPressed("reel_up") && !Input.IsActionPressed("reel_down")) 
            { 
                reelForce = directionToHookPoint * Parent.MovementComponent.GetUpwardsReelingForce();
            } else if (!Input.IsActionPressed("reel_up") && Input.IsActionPressed("reel_down"))
            {
                reelForce = -directionToHookPoint * Parent.MovementComponent.GetDownwardsReelingForce();
            }

            var velocityLerpSpeed = 2;
            Vector2 lerpVector = Parent.LinearVelocity.Lerp(reelForce, velocityLerpSpeed * delta);
            Parent.LinearVelocity = lerpVector;

            return null;
        }

        public override PlayerState? ProcessInput(InputEvent input)
        {

            if (!Input.IsActionPressed("reel_up") && !Input.IsActionPressed("reel_down"))
            {
                return hookedState;
            }

            return null;

        }

    }

}
