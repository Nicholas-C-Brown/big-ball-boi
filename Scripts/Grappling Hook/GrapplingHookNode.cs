using BigBallBoi.Scripts.Grappling_Hook;
using BigBallBoiGame.Scripts.GrapplingHook.State;
using Godot;
using System;

namespace BigBallBoiGame.Scripts.GrapplingHook
{

    public partial class GrapplingHookNode : Node2D
    {
        [Export]public GrapplingHookStatsResource Stats { get; private set; }

        [Export] private PackedScene PinJointScene;
        [Export] private PackedScene HookBodyScene;

        public PinJoint2D PinJoint { get; private set; }
        public StaticBody2D HookBody { get; private set; }
        public Area2D HookPoint { get; private set; }
        public Line2D HookLine { get; private set; }
        public GrapplingHookInputHandler InputHandler { get; private set; }
        public float AimDistance { get; private set; }

        public Action HookAttached { get; set; }
        public Action HookDetached { get; set; }

        [Export] public GrapplingHookStateMachine StateMachine { get; private set; }

        public override void _Ready()
        {
            //Instantiate required components on root node
            var root = GetTree().Root;
            PinJoint = PinJointScene.Instantiate<PinJoint2D>();
            HookBody = HookBodyScene.Instantiate<StaticBody2D>();
            root.Ready += () => root.AddChild(PinJoint);
            root.Ready += () => root.AddChild(HookBody);

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


