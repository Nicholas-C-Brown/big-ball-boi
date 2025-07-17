using Godot;

namespace BigBallBoiGame.Scripts.Gun.Shotgun.State
{

    public partial class Idle : GunState
    {

        [Export] private GunState shootState;
        [Export] private GunState reloadState;

        public override GunState? ProcessFrame(float delta)
        {
            LookAtMouse();
            HandleSpriteFlip();

            return null;
        }

        public override GunState? ProcessInput(InputEvent input)
        {
            if(Parent.InputHandler.WantsToShoot())
            {
                return shootState;
            }

            if (Parent.InputHandler.WantsToReload())
            {
                return reloadState;
            }

            return null;
        }

    }

}

