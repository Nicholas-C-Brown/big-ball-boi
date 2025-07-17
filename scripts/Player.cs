using BigBallBoiGame.Component.Movement;
using BigBallBoiGame.State.PlayerStates;
using Godot;

namespace BigBallBoiGame
{

    public partial class Player : RigidBody2D, IAnimatable
    {

        public IMovementComponent MovementComponent { get; private set; }
        public AnimatedSprite2D AnimationComponent { get; private set; }
        public GrapplingHook GrapplingHook { get; private set; }
        public Shotgun Shotgun { get; private set; }
       
        [Export] public PinJoint2D GrapplingHookPinJoint { get; private set; }
        [Export] public StaticBody2D GrapplingHookStaticBody {  get; private set; }
        [Export] public PlayerStateMachine StateMachine { get; private set; }

        private ShapeCast2D groundCast;

        public override void _Ready()
        {
            MovementComponent = GetNode<IMovementComponent>("MovementComponent");
            AnimationComponent = GetNode<AnimatedSprite2D>("AnimationComponent");
            GrapplingHook = GetNode<GrapplingHook>("GrapplingHook");
            Shotgun = GetNode<Shotgun>("Shotgun");

            GrapplingHook.HookAttached += StateMachine.OnHookAttached;
            GrapplingHook.HookDetached += StateMachine.OnHookDetacted;

            Shotgun.Shoot += ApplyGunKnockback;

            StateMachine.Initialize(this);

            groundCast = GetNode<ShapeCast2D>("GroundCast");
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

        public bool IsOnFloor()
        {
            return groundCast.IsColliding();
        }

        public void ApplyGunKnockback(float knockback)
        {
            ApplyCentralImpulse(-Vector2.FromAngle(Shotgun.GlobalRotation) * knockback);
        }

    }

}


