using Godot;
using System;

public partial class AnimatableState : State
{

    [Export] protected String? animationName;

    public override void Enter()
    {
        AnimatedSprite2D? animationComponent = ComponentProvider.GetOptionalComponent<AnimatedSprite2D>();

        if (animationName != null)
        {
            animationComponent?.Play(animationName);
        }
    }

}

