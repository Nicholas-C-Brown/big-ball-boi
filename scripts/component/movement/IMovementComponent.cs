using Godot;
using System;

namespace BigBallBoiGame.Component.Movement
{

    public interface IMovementComponent
    {

        /// <returns>The entity's movement speed</returns>
        float GetMovementForce();

        /// <returns>The entity's maximum movement speed</returns>
        float GetMaxMovementSpeed();

        /// <returns>The entity's movement direction multiplied by its movement speed</returns>
        float GetMovement();

        float GetHookedMovementForce();

        float GetHookedMovement();

        float GetUpwardsReelingForce();

        float GetDownwardsReelingForce();

        /// <returns>The entity's jump strength</returns>
        float GetJumpStrength();

        /// <returns>True if the entity wants to jump</returns>
        bool WantsToJump();

    }

}
