using Godot;
using System;

namespace BigBallBoiGame.Scripts.Component
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
