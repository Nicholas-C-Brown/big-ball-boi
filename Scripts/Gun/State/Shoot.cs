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
            for (int i = 0; i < 10; i++)
            {
                Bullet bullet = Parent.BulletScene.Instantiate<Bullet>();

                //Bullet direction
                bullet.GlobalPosition = Parent.GlobalPosition;
                Vector2 bulletDirection = Vector2.FromAngle(Parent.GlobalRotation);

                //Randomize the direction a little for bullet spread
                float spreadRadians = Parent.GunComponent.GetBulletSpreadRadians();
                float angle = rng.RandfRange(-spreadRadians, spreadRadians);

                //Calculate bullet velocity
                Vector2 bulletVelocity = bulletDirection.Rotated(angle) * Parent.GunComponent.GetBulletSpeed();
                bullet.ApplyCentralImpulse(bulletVelocity);

                bullet.Damage = Parent.GunComponent.GetDamage();

                GetTree().Root.AddChild(bullet);
            }

            Parent.Shoot?.Invoke(Parent.GunComponent.GetKnockbackForce());
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
