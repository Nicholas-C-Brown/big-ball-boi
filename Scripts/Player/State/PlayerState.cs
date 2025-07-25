
using BigBallBoiGame.State;
using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State 
{

    public abstract partial class PlayerState : AnimatableState<PlayerNode> 
    {

        protected void ApplyMovement()
        {

            float movement = Parent.InputHandler.GetHorizontalMovementDirection() * Parent.Stats.MovementForce;

            var linearVelocity = Parent.LinearVelocity.X;

            //If the player is already movement faster than their max movement speed
            //then don't add any more force in the same direction
            if (Mathf.Abs(linearVelocity) > Parent.Stats.MaxAppliedMovementSpeed)
            {

                if (linearVelocity < 0 && movement < 0)
                {
                    return;
                }

                if (linearVelocity > 0 && movement > 0)
                {
                    return;
                }

            }

            Parent.ApplyCentralForce(new Vector2(movement, 0));
 
        }

        protected void HandleSpriteFlip()
        {

            //Calculates the player's X velocity relative to its current rotation in the world
            Vector2 playerGlobalRotationVector = Vector2.FromAngle(Parent.GlobalRotation);
            float relativeVelocityX = Parent.LinearVelocity.Dot(playerGlobalRotationVector);

            if (relativeVelocityX < 0)
            {
                Parent.AnimationComponent.FlipH = true;
            }

            if (relativeVelocityX > 0)
            {
                Parent.AnimationComponent.FlipH = false;
            }
        }

        protected void RealignGlobalRotation(float delta)
        {
            float realignRotationSpeed = 5;
            Parent.GlobalRotation = Mathf.Lerp(Parent.GlobalRotation, 0, realignRotationSpeed * delta);
        }

    }

}

