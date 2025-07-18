using BigBallBoi.Scripts.Gun;
using BigBallBoi.Scripts.Player;
using BigBallBoiGame.Scripts.GrapplingHook;
using BigBallBoiGame.Scripts.Player.State;
using Godot;

namespace BigBallBoiGame.Scripts.Player
{

    public partial class PlayerNode : RigidBody2D, IAnimatable
    {

        [Export] public PlayerStatsResource Stats { get; private set; }

        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public AnimatedSprite2D AnimationComponent { get; private set; }
        public GrapplingHookNode GrapplingHook { get; private set; }
        public GunNode Gun { get; private set; }

        private ShapeCast2D groundCast;

        public override void _Ready()
        {
            StateMachine = GetNode<PlayerStateMachine>("StateMachine");
            InputHandler = GetNode<PlayerInputHandler>("InputHandler");
            AnimationComponent = GetNode<AnimatedSprite2D>("AnimationComponent");
            GrapplingHook = GetNode<GrapplingHookNode>("GrapplingHook");
            Gun = GetNode<GunNode>("Shotgun");

            groundCast = GetNode<ShapeCast2D>("GroundCast");

            //Configure Action callbacks
            GrapplingHook.HookAttached += StateMachine.OnHookAttached;
            GrapplingHook.HookDetached += StateMachine.OnHookDetacted;

            Gun.Shoot += ApplyGunKnockback;


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

        public bool IsOnFloor()
        {
            return groundCast.IsColliding();
        }

        public void ApplyGunKnockback()
        {
            ApplyCentralImpulse(-Vector2.FromAngle(Gun.GlobalRotation) * Gun.Stats.KnockbackForce);
        }

    }

}


