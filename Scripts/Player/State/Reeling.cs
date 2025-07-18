using Godot;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Reeling : PlayerState
    {

        [Export] public PlayerState hookedState;
        [Export] public PlayerState fallState;

        public override PlayerState? ProcessPhysics(float delta)
        {
            Vector2 directionToHookPoint = (Parent.GrapplingHook.PinJoint.GlobalPosition - Parent.GlobalPosition).Normalized();
            float reelingDirection = Parent.InputHandler.GetVerticalReelingDirection();

            float reelingForce = 0;
            if (reelingDirection < 0)
            {
                reelingForce = Parent.Stats.DownwardsReelingForce;
            }
            else if (reelingDirection > 0)
            {
                reelingForce = Parent.Stats.UpwardsReelingForce;
            }

            Vector2 reelingVector = reelingForce * directionToHookPoint;
            
            var velocityLerpSpeed = 2;
            Vector2 lerpVector = Parent.LinearVelocity.Lerp(reelingVector, velocityLerpSpeed * delta);
            Parent.LinearVelocity = lerpVector;

            return null;
        }

        public override PlayerState? ProcessInput(InputEvent input)
        {

            if (!Parent.InputHandler.WantsToReel())
            {
                return hookedState;
            }

            return null;

        }

    }

}
