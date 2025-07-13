using BigBallBoiGame.State;
using BigBallBoiGame.State.PlayerStates;
using Godot;

namespace BigBallBoiGame
{

    public partial class Player : CharacterBody2D, IAnimatable
    {

        public IMovementComponent MovementComponent { get; private set; }
        public AnimatedSprite2D AnimationComponent { get; private set; }

        [Export] private PlayerStateMachine stateMachine;

        public override void _Ready()
        {
            MovementComponent = GetNode<IMovementComponent>("MovementComponent");
            AnimationComponent = GetNode<AnimatedSprite2D>("AnimationComponent");

            stateMachine.Initialize(this);
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


