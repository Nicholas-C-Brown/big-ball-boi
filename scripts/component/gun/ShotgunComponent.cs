using Godot;
using System;

namespace BigBallBoiGame.Component.Gun
{

    public partial class ShotgunComponent : Node, IGunComponent
    {

        [Export] private int clipSize = 2;
        [Export] private float reloadTime = 3;
        [Export] private float knockbackForce = 1000;
        [Export] private float damage = 5;
        [Export] private float bulletCount = 10;
        [Export] private float bulletSpeed = 1000;
        [Export] private float bulletSpreadDegrees = 20;

        public int GetClipSize()
        {
            return clipSize;
        }

        public float GetDamage()
        {
            return damage;
        }

        public float GetBulletCount()
        {
            return bulletCount;
        }

        public float GetBulletSpeed()
        {
            return bulletSpeed;
        }

        public float GetBulletSpreadRadians()
        {
            return Mathf.DegToRad(bulletSpreadDegrees);
        }

        public float GetKnockbackForce()
        {
            return knockbackForce;
        }

        public float GetReloadTime()
        {
            return reloadTime;
        }

        public bool WantsToShoot()
        {
            return Input.IsActionJustPressed("shoot");
        }

    }

}
