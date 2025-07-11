using Godot;
using System;

public interface IMovementComponent
{

    /// <returns>The entity's movement speed</returns>
    float GetMovementForce();

    /// <returns>The entity's maximum movement speed</returns>
    float GetMaxMovementSpeed();

    /// <returns>The entity's movement direction multiplied by its movement speed</returns>
    float GetMovement();

    /// <returns>The entity's jump strength</returns>
    float GetJumpStrength();

    /// <returns>True if the entity wants to jump</returns>
    bool WantsToJump();

    /// <summary>
    /// The strength of the deceleration force applied to the entity
    /// </summary>
    /// <returns>The entity's deceleration force</returns>
    float GetDecelerationForce();

}
