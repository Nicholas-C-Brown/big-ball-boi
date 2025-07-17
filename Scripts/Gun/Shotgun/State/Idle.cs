using Godot;

namespace BigBallBoiGame.Scripts.Gun.Shotgun.State
{

    public partial class Idle : ShotgunState
    {

        [Export] private ShotgunState shootState;

        public override ShotgunState? ProcessFrame(float delta)
        {
            LookAtMouse();
            HandleSpriteFlip();

            return null;
        }

        public override ShotgunState? ProcessInput(InputEvent input)
        {
            if(Parent.GunComponent.WantsToShoot())
            {
                return shootState;
            }

            return null;
        }

    }

}

