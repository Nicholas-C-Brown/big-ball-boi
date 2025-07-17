using Godot;
using System;

namespace BigBallBoiGame.State
{

    public abstract partial class AnimatableState<T> : State<T> where T: Node, IAnimatableState 

    {

        [Export] protected string? animationName;

        public override void Enter()
        {
            if (animationName != null)
            {
                Parent.AnimationComponent.Play(animationName);
            }
        }

    }

}

