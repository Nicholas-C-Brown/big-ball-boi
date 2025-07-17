using BigBallBoiGame.Scripts.GrapplingHook.State;
using Godot;
using System;

namespace BigBallBoiGame.Scripts.GrapplingHook
{

    public partial class GrapplingHookNode : Node2D
    {

        public Area2D HookPoint { get; private set; }
        public Line2D HookLine { get; private set; }
        public GrapplingHookInputHandler InputHandler { get; private set; }

        public float AimDistance { get; private set; }

        public Action HookAttached;
        public Action HookDetached;

        [Export] public GrapplingHookStateMachine StateMachine { get; private set; }

        public override void _Ready()
        {
            HookPoint = GetNode<Area2D>("HookPoint");
            HookLine = GetNode<Line2D>("HookLine");
            InputHandler = GetNode<GrapplingHookInputHandler>("InputHandler");

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


