using Godot;
using System;

public partial class PlayerMovementComponent : Node, IMovementComponent
{

    [Export(PropertyHint.Range, "100, 1000")] private float jumpStrength;

    [Export(PropertyHint.Range, "100, 2000")] private float movementForce;
    [Export(PropertyHint.Range, "100, 500")] private float maxMoveSpeed;

    [Export(PropertyHint.Range, "100, 2000")] private float hookedMovementForce;


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

    public float GetHookedMovementForce()
    {
        return hookedMovementForce;
    }

    public float GetHookedMovement()
    {
        return Input.GetAxis("move_left", "move_right") * hookedMovementForce;
    }

    public bool WantsToJump()
    {
        return Input.IsActionJustPressed("jump");
    }

   
}

    
