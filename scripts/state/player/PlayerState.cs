
using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public abstract partial class PlayerState : AnimatableState<Player> 
    {

        protected Vector2 gravity = new Vector2(0, ProjectSettings.GetSetting("physics/2d/default_gravity").As<float>());

        protected void ApplyGravity(float delta)
        {
            Parent.Velocity += gravity * delta;
        }

        protected void ApplyMovement(float delta)
        {
            float movement = Parent.MovementComponent.GetMovement();

            //Decelerate if the player is not moving
            if (movement == 0)
            {
                ApplyDeceleration(delta);
                return;
            }

            float maxMovementSpeed = Parent.MovementComponent.GetMaxMovementSpeed();

            Parent.Velocity += new Vector2(movement * delta, 0);

            float unclampedVelocity = Parent.Velocity.X;
            float clampedVelocity = Mathf.Clamp(unclampedVelocity, -maxMovementSpeed, maxMovementSpeed);

            Parent.Velocity = new Vector2(clampedVelocity, Parent.Velocity.Y);
        }

        protected void ApplyDeceleration(float delta)
        {
            float horizontalVelocity = Mathf.Lerp(Parent.Velocity.X, 0, Parent.MovementComponent.GetDecelerationForce() * delta);
            Parent.Velocity = new Vector2(horizontalVelocity, Parent.Velocity.Y);
        }

        protected void HandleSpriteFlip()
        {
            if (Parent.Velocity.X < 0)
            {
                Parent.AnimationComponent.FlipH = true;
            }

            if (Parent.Velocity.X > 0)
            {
                Parent.AnimationComponent.FlipH = false;
            }
        }

    }

}

