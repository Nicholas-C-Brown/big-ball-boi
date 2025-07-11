using Godot;
using System;

public abstract partial class AnimatableState : State
{

    [Export] protected String? animationName;

    [Export] protected AnimatedSprite2D _animationComponent;

    public override void Enter()
    {
        _animationComponent = ComponentProvider.GetRequiredComponent<AnimatedSprite2D>();

        if (animationName != null)
        {
            _animationComponent?.Play(animationName);
        }
    }

}

