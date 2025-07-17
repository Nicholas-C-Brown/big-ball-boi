using Godot;
using System;

namespace BigBallBoiGame.Component.Gun
{

    public interface IGunComponent
    {
        int GetClipSize();

        float GetDamage();

        float GetBulletCount();

        float GetBulletSpeed();

        float GetBulletSpreadRadians();

        float GetKnockbackForce();

        float GetReloadTime();

        bool WantsToShoot();


    }

}
