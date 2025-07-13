using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Move : PlayerState
    {

        [Export] private State<Player> idleState;
        [Export] private State<Player> jumpState;
        [Export] private State<Player> fallState;

        public override State<Player>? ProcessInput(InputEvent input)
        {
            if (Parent.MovementComponent.WantsToJump())
            {
                return jumpState;
            }

            return null;
        }

        public override State<Player>? ProcessFrame(float delta)
        {
            HandleSpriteFlip();

            float absoluteHorizontalVelocity = Mathf.Abs(Parent.Velocity.X);
            float maxMovementSpeed = Parent.MovementComponent.GetMaxMovementSpeed();
            float speedScaleFactor = absoluteHorizontalVelocity / maxMovementSpeed;

            float minimumMoveAnimationSpeed = 0.6f;
            Parent.AnimationComponent.SpeedScale = Mathf.Clamp(speedScaleFactor, minimumMoveAnimationSpeed, 1);

            return null;
        }

        public override State<Player>? ProcessPhysics(float delta)
        {

            ApplyGravity(delta);
            ApplyMovement(delta);

            Parent.MoveAndSlide();

            int idleThreshold = 10;
            if (Mathf.Abs(Parent.Velocity.X) < idleThreshold && Parent.MovementComponent.GetMovement() == 0)
            {
                return idleState;
            }

            if (!Parent.IsOnFloor())
            {
                return fallState;
            }

            return null;
        }

        public override void Exit()
        {
            Parent.AnimationComponent.SpeedScale = 1;
        }

    }

}
