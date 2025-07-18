using Godot;

namespace BigBallBoiGame.Scripts.Gun.Shotgun.State
{

    public partial class Shoot : GunState
    {

        [Export] GunState idleState;
        [Export] GunState reloadState;

        public override void Enter()
        {
            //Create bullets
            RandomNumberGenerator rng = new RandomNumberGenerator();
            for (int i = 0; i < Parent.Stats.BulletCount; i++)
            {
                Bullet bullet = Parent.BulletScene.Instantiate<Bullet>();

                //Bullet direction
                bullet.GlobalPosition = Parent.GlobalPosition;
                Vector2 bulletDirection = Vector2.FromAngle(Parent.GlobalRotation);

                //Randomize the direction a little for bullet spread
                float spreadRadians = Mathf.DegToRad(Parent.Stats.BulletSpreadDegrees);
                float angle = rng.RandfRange(-spreadRadians, spreadRadians);

                //Calculate bullet velocity
                Vector2 bulletVelocity = bulletDirection.Rotated(angle) * Parent.Stats.BulletSpeed;
                bullet.ApplyCentralImpulse(bulletVelocity);

                bullet.Damage = Parent.Stats.Damage;

                GetTree().Root.AddChild(bullet);
            }

            Parent.Shoot?.Invoke();
            Parent.SubtractAmmo();

        }

        public override GunState? ProcessFrame(float delta)
        {
            if (Parent.IsClipEmpty())
            {
                return reloadState;
            }

            return idleState;
        }

    }

}
