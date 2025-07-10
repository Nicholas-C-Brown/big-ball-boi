using Godot;

public partial class Player : CharacterBody2D
{

    private static Vector2 gravity = new Vector2(0, 1f);

    private Vector2 speedVector = new Vector2(4f, 0);
    private Vector2 jumpVector = new Vector2(0, -100f);
    private float rotationDivisor = 1000;
    private float frictionValue = 0.01f;

    public override void _PhysicsProcess(double delta)
    {
        HandleMovement();
        ApplyRotation();
        ApplyFriction();
        ApplyGravity();
        MoveAndSlide();
    }

    private void HandleMovement()
    {
        if(Input.IsActionPressed("Left"))
        {
            Velocity -= speedVector;
            
        }
        if (Input.IsActionPressed("Right"))
        {
            Velocity += speedVector;
        }
        if(Input.IsActionJustPressed("Jump"))
        {
            Velocity += jumpVector;
        }

    }

    private void ApplyRotation()
    {
        Rotation += Velocity.X / rotationDivisor;
    }

    private void ApplyFriction()
    {
        float x = Mathf.Lerp(Velocity.X, 0, frictionValue);
        Velocity = new Vector2(x, Velocity.Y);
    }

    private void ApplyGravity()
    {
        Velocity += gravity;
    }




}
