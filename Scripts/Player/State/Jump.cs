using Godot;
using System;

namespace BigBallBoiGame.Scripts.Player.State
{

    public partial class Jump : PlayerState
    {

        [Export] private PlayerState idleState;
        [Export] private PlayerState moveState;
        [Export] private PlayerState fallState;

        /// <summary>
        /// Used to keep the player from immediately exiting the jump state
        /// </summary>
        private float stateChangeLockoutTimer;

        public override void Enter()
        {
            base.Enter();

            Parent.ApplyCentralImpulse(new Vector2(0, Parent.Stats.JumpStrength));

            stateChangeLockoutTimer = 0.2f;
        }

        public override PlayerState? ProcessPhysics(float delta)
        {
            ApplyMovement();
            HandleSpriteFlip();

            stateChangeLockoutTimer -= delta;

            if (Parent.LinearVelocity.Y > 0 && stateChangeLockoutTimer < 0)
            {
                return fallState;
            }

            if (Parent.IsOnFloor() && stateChangeLockoutTimer < 0)
            {
                return Parent.LinearVelocity.X == 0 ? idleState : moveState;
            }

            return null;

        }

    }

}
