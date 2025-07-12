
using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates
{

    public abstract partial class PlayerState : AnimatableState
    {

        protected Vector2 gravity = new Vector2(0, ProjectSettings.GetSetting("physics/2d/default_gravity").As<float>());

        protected Player _parent;
        protected IMovementComponent _movementComponent;

        public override void Initialize()
        {
            _parent = ComponentProvider.GetParentComponent<Player>();
            _movementComponent = ComponentProvider.GetRequiredComponent<IMovementComponent>();
        }

        protected void ApplyGravity(float delta)
        {
            _parent.Velocity += gravity * delta;
        }

        protected void ApplyMovement(float delta)
        {
            float movement = _movementComponent.GetMovement();

            //Decelerate if the player is not moving
            if (movement == 0)
            {
                ApplyDeceleration(delta);
                return;
            }

            float maxMovementSpeed = _movementComponent.GetMaxMovementSpeed();

            _parent.Velocity += new Vector2(movement * delta, 0);

            float unclampedVelocity = _parent.Velocity.X;
            float clampedVelocity = Mathf.Clamp(unclampedVelocity, -maxMovementSpeed, maxMovementSpeed);

            _parent.Velocity = new Vector2(clampedVelocity, _parent.Velocity.Y);
        }

        protected void ApplyDeceleration(float delta)
        {
            float horizontalVelocity = Mathf.Lerp(_parent.Velocity.X, 0, _movementComponent.GetDecelerationForce() * delta);
            _parent.Velocity = new Vector2(horizontalVelocity, _parent.Velocity.Y);
        }

        protected void HandleSpriteFlip()
        {
            if (_parent.Velocity.X < 0)
            {
                _animationComponent.FlipH = true;
            }

            if (_parent.Velocity.X > 0)
            {
                _animationComponent.FlipH = false;
            }
        }

    }

}

