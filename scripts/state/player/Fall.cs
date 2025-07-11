using Godot;
using System;

public partial class Fall : State
{

    [Export] private State idleState;
    [Export] private State moveState;

    private CharacterBody2D _parent;

    public override void Initialize()
    {
        _parent = ComponentProvider.GetParentComponent<CharacterBody2D>();
    }

    public override State? ProcessPhysics(float delta)
    {
        _parent.Velocity += gravity * delta;
     
        //Movement
        float movement = Input.GetAxis("move_left", "move_right");
        _parent.Velocity = new Vector2(movement * 100f, _parent.Velocity.Y);

        _parent.MoveAndSlide();


        if (_parent.IsOnFloor())
        {
            return movement == 0 ? idleState : moveState;
        }

        return null;
    }

}
