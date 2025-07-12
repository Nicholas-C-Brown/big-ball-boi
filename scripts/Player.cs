using BigBallBoiGame.State;
using Godot;

namespace BigBallBoiGame
{

    public partial class Player : CharacterBody2D
    {

        private ComponentProvider componentProvider;
        private StateMachine stateMachine;

        public override void _Ready()
        {
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


