using Godot;
using System;

namespace BigBallBoiGame.Scripts.GrapplingHook.State
{

    public partial class Aiming : GrapplingHookState
    {

        [Export] private GrapplingHookState extendState;

        public override void Enter()
        {
            Parent.HookPoint.Position = new Vector2(Parent.AimDistance, 0);
            Parent.HookLine.Points = Array.Empty<Vector2>();
        }

        public override GrapplingHookState? ProcessFrame(float delta)
        {
            Vector2 mousePosition = Parent.GetGlobalMousePosition();
            Parent.LookAt(mousePosition);

            if(Parent.InputHandler.WantsToExtendHook())
            {
                return extendState;
            }

            return null;
        }



    }

}
