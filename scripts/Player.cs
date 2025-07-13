using BigBallBoiGame.State;
using BigBallBoiGame.State.PlayerStates;
using Godot;

namespace BigBallBoiGame
{

    public partial class Player : CharacterBody2D, IAnimatable
    {

        public IMovementComponent MovementComponent { get; private set; }
        public AnimatedSprite2D AnimationComponent { get; private set; }
        public GrapplingHook GrapplingHook { get; private set; }

        [Export] public PlayerStateMachine StateMachine { get; private set; }

        public override void _Ready()
        {
            MovementComponent = GetNode<IMovementComponent>("MovementComponent");
            AnimationComponent = GetNode<AnimatedSprite2D>("AnimationComponent");
            GrapplingHook = GetNode<GrapplingHook>("GrapplingHook");

            GrapplingHook.Hooked += StateMachine.AttachHook;

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


