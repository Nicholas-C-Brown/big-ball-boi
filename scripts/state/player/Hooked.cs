using BigBallBoiGame;
using BigBallBoiGame.State;
using BigBallBoiGame.State.PlayerStates;
using Godot;
using System;

namespace BigBallBoiGame.State.PlayerStates {

    public partial class Hooked : PlayerState
    {

        public override void Enter()
        {

            Vector2 hookPosition = Parent.GrapplingHook.HookPoint.GlobalPosition;
            Parent.GrapplingHookPinJoint.GlobalPosition = hookPosition;

            Parent.GrapplingHookPinJoint.NodeA = Parent.GrapplingHookStaticBody.GetPath();
            Parent.GrapplingHookPinJoint.NodeB = Parent.GetPath();
            Parent.LockRotation = false;

        }

        public override void Exit()
        {
            Parent.GrapplingHookPinJoint.NodeA = new NodePath("");
            Parent.GrapplingHookPinJoint.NodeB = new NodePath("");

            Parent.GlobalRotation = 0;
            Parent.LockRotation = true;
        }

        public override State<Player>? ProcessPhysics(float delta)
        {

            float movement = Parent.MovementComponent.GetMovement();
            Parent.ApplyCentralForce(new Vector2(movement, 0).Rotated(Parent.Rotation));

            HandleSpriteFlip();

            return null;

        }
    }
}
