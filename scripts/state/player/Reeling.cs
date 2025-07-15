using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Reeling : State<Player>
    {

        [Export] public State<Player> hookedState;
        [Export] public State<Player> fallState;

        public override State<Player>? ProcessPhysics(float delta)
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

            var magicLerpNumber = 2;
            Vector2 lerpVector = Parent.LinearVelocity.Lerp(reelForce, magicLerpNumber * delta);
            Parent.LinearVelocity = lerpVector;

            return null;
        }

        public override State<Player>? ProcessInput(InputEvent input)
        {

            if (!Input.IsActionPressed("reel_up") && !Input.IsActionPressed("reel_down"))
            {
                return hookedState;
            }

            return null;

        }

    }

}
