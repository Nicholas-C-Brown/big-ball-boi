using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Move : PlayerState
    {

        [Export] private PlayerState idleState;
        [Export] private PlayerState jumpState;
        [Export] private PlayerState fallState;

        public override PlayerState? ProcessInput(InputEvent input)
        {
            if (Parent.InputHandler.WantsToJump())
            {
                return jumpState;
            }

            return null;
        }

        public override PlayerState? ProcessFrame(float delta)
        {
            HandleSpriteFlip();

            float absoluteHorizontalVelocity = Mathf.Abs(Parent.LinearVelocity.X);
            float maxMovementSpeed = Parent.MovementComponent.GetMaxMovementSpeed();
            float speedScaleFactor = absoluteHorizontalVelocity / maxMovementSpeed;

            float minimumMoveAnimationSpeed = 0.6f;
            Parent.AnimationComponent.SpeedScale = Mathf.Clamp(speedScaleFactor, minimumMoveAnimationSpeed, 1);

            return null;
        }

        public override PlayerState? ProcessPhysics(float delta)
        {

            ApplyMovement();

            int idleThreshold = 10;
            if (Mathf.Abs(Parent.LinearVelocity.X) < idleThreshold && Parent.InputHandler.GetHorizontalMovementDirection() == 0)
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
