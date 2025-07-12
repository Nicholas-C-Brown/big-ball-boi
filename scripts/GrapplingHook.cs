using BigBallBoiGame.State;
using Godot;

namespace BigBallBoiGame
{

    public partial class GrapplingHook : Node2D
    {

        public Area2D HookPoint { get; private set; }
        public Line2D HookLine { get; private set; }

        public float AimDistance { get; private set; }

        private ComponentProvider componentProvider;
        private StateMachine stateMachine;

        public override void _Ready()
        {
            HookPoint = GetNode<Area2D>("HookPoint");
            HookLine = GetNode<Line2D>("HookLine");

            AimDistance = HookPoint.Position.Length();

            componentProvider = GetNode<ComponentProvider>("ComponentProvider");
            stateMachine = GetNode<StateMachine>("StateMachine");
            stateMachine.Initialize(componentProvider);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            stateMachine.ProcessInput(@event);
        }

        public override void _Process(double delta)
        {
            stateMachine.ProcessFrame((float)delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            stateMachine.ProcessPhysics((float)delta);
        }

    }

}


