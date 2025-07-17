using Godot;
using System;

public partial class Bullet : RigidBody2D
{

    [Export] private float lifeTime;

    public float Damage {  get; set; }

    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        timer.Timeout += QueueFree;
    }

}
