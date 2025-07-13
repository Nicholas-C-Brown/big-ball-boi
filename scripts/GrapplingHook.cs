using BigBallBoiGame.State;
using BigBallBoiGame.State.PlayerStates;
using Godot;
using System;

namespace BigBallBoiGame
{

    public partial class GrapplingHook : Node2D
    {

        public Area2D HookPoint { get; private set; }
        public Line2D HookLine { get; private set; }

        public float AimDistance { get; private set; }

        public Action<bool> Hooked;

        [Export] public GrapplingHookStateMachine StateMachine { get; private set; }

        public override void _Ready()
        {
            HookPoint = GetNode<Area2D>("HookPoint");
            HookLine = GetNode<Line2D>("HookLine");

            AimDistance = HookPoint.Position.Length();

            StateMachine.Initialize(this);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            StateMachine.ProcessInput(@event);
        }

        public override void _Process(double delta)
        {
            StateMachine.ProcessFrame((float)delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            StateMachine.ProcessPhysics((float)delta);
        }

    }

}


