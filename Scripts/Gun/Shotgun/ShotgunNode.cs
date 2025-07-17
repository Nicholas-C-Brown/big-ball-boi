using BigBallBoiGame.Scripts.Component;
using BigBallBoiGame.Scripts.Gun.Shotgun.State;
using Godot;
using System;

namespace BigBallBoiGame.Scripts.Gun.Shotgun  
{

    public partial class ShotgunNode : Node2D
    {

        [Export] public PackedScene BulletScene { get; private set; }

        public Sprite2D Sprite { get; private set; }
        public ShotgunStateMachine StateMachine { get; private set; }
        public IGunComponent GunComponent { get; private set; }

        public Action<float> Shoot;

        private int ammo;

        public override void _Ready()
        {
            Sprite = GetNode<Sprite2D>("Sprite2D");
            StateMachine = GetNode<ShotgunStateMachine>("StateMachine");
            GunComponent = GetNode<IGunComponent>("GunComponent");

            StateMachine.Initialize(this);

            ammo = GunComponent.GetClipSize();
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
            ammo = GunComponent.GetClipSize();
        }

        public void SubtractAmmo()
        {
            ammo--;
        }

    }

}

