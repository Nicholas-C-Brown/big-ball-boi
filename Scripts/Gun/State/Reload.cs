using Godot;

namespace BigBallBoiGame.Scripts.Gun.Shotgun.State {

    public partial class Reload : GunState
    {

        [Export] GunState idleState;

        private float reloadTimer;

        public override void Enter()
        {
            //Create bullets
            GD.Print("Reloading");

            Parent.Reload();
            reloadTimer = Parent.GunComponent.GetReloadTime();

        }

        public override GunState? ProcessFrame(float delta)
        {
            reloadTimer -= delta;

            if (reloadTimer < 0)
            {
                return idleState;
            }

            return null;
        }

    }
    
}
