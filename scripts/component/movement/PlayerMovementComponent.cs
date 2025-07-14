using Godot;
using System;

public partial class PlayerMovementComponent : Node, IMovementComponent
{

    [Export(PropertyHint.Range, "100, 1000")] private float jumpStrength = 400;

    [Export(PropertyHint.Range, "1000, 5000")] private float movementForce = 200;
    [Export(PropertyHint.Range, "100, 500")] private float maxMoveSpeed = 100;


    public float GetJumpStrength()
    {
        return -jumpStrength;
    }

    public float GetMovementForce()
    {
        return movementForce;
    }

    public float GetMaxMovementSpeed()
    {
        return maxMoveSpeed;
    }


    public float GetMovement()
    {
        return Input.GetAxis("move_left", "move_right") * movementForce;
    }

    public bool WantsToJump()
    {
        return Input.IsActionJustPressed("jump");
    }

}

    
