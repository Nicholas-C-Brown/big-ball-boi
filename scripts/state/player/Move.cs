using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public partial class Move : PlayerState
    {

        [Export] private State idleState;
        [Export] private State jumpState;
        [Export] private State fallState;

        public override State? ProcessInput(InputEvent input)
        {
            if (_movementComponent.WantsToJump())
            {
                return jumpState;
            }

            return null;
        }

        public override State? ProcessFrame(float delta)
        {
            HandleSpriteFlip();

            float absoluteHorizontalVelocity = Mathf.Abs(_parent.Velocity.X);
            float maxMovementSpeed = _movementComponent.GetMaxMovementSpeed();
            float speedScaleFactor = absoluteHorizontalVelocity / maxMovementSpeed;

            float minimumMoveAnimationSpeed = 0.6f;
            _animationComponent.SpeedScale = Mathf.Clamp(speedScaleFactor, minimumMoveAnimationSpeed, 1);

            return null;
        }

        public override State? ProcessPhysics(float delta)
        {

            ApplyGravity(delta);
            ApplyMovement(delta);

            _parent.MoveAndSlide();

            int idleThreshold = 10;
            if (Mathf.Abs(_parent.Velocity.X) < idleThreshold && _movementComponent.GetMovement() == 0)
            {
                return idleState;
            }

            if (!_parent.IsOnFloor())
            {
                return fallState;
            }

            return null;
        }

        public override void Exit()
        {
            _animationComponent.SpeedScale = 1;
        }

    }

}
