using BigBallBoi.Scripts.Gun;
using BigBallBoiGame.Scripts.GrapplingHook;
using BigBallBoiGame.Scripts.Gun.Shotgun;
using BigBallBoiGame.Scripts.Player.Component;
using BigBallBoiGame.Scripts.Player.State;
using Godot;

namespace BigBallBoiGame.Scripts.Player
{

    public partial class PlayerNode : RigidBody2D, IAnimatableState
    {

        public PlayerMovementComponent MovementComponent { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public AnimatedSprite2D AnimationComponent { get; private set; }
        public GrapplingHookNode GrapplingHook { get; private set; }
        public GunNode Shotgun { get; private set; }
       
        [Export] public PinJoint2D GrapplingHookPinJoint { get; private set; }
        [Export] public StaticBody2D GrapplingHookStaticBody {  get; private set; }
        [Export] public PlayerStateMachine StateMachine { get; private set; }

        private ShapeCast2D groundCast;

        public override void _Ready()
        {
            MovementComponent = GetNode<PlayerMovementComponent>("MovementComponent");
            InputHandler = GetNode<PlayerInputHandler>("InputHandler");
            AnimationComponent = GetNode<AnimatedSprite2D>("AnimationComponent");
            GrapplingHook = GetNode<GrapplingHookNode>("GrapplingHook");
            Shotgun = GetNode<GunNode>("Shotgun");

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


