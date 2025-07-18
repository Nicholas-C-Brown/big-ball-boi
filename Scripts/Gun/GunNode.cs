using BigBallBoiGame.Scripts.Gun;
using BigBallBoiGame.Scripts.Gun.Shotgun.State;
using Godot;
using System;

namespace BigBallBoi.Scripts.Gun
{
    public partial class GunNode : Node2D
    {

        [Export] public PackedScene BulletScene { get; private set; }
        [Export] public GunStatsResource Stats { get; private set; }
        
        public GunInputHandler InputHandler { get; protected set; }
        public GunStateMachine StateMachine { get; private set; }
        public Sprite2D Sprite { get; private set; }

        public Action Shoot { get; set; }

        private int ammo;

        public override void _Ready()
        {
            InputHandler = GetNode<GunInputHandler>("InputHandler");
            Sprite = GetNode<Sprite2D>("Sprite2D");
            StateMachine = GetNode<GunStateMachine>("StateMachine");

            //Configure sprite
            Sprite.Texture = Stats.Texture;
            Sprite.Position = Stats.SpriteOffset;

            StateMachine.Initialize(this);

            Reload();
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

        public bool IsClipEmpty()
        {
            return ammo == 0;
        }

        public void Reload()
        {
            ammo = Stats.ClipSize;
        }

        public void SubtractAmmo()
        {
            ammo--;
        }

    }
}
