using Godot;

namespace BigBallBoi.Scripts.Gun
{
    public partial class GunStatsResource : Resource
    {

        [Export] public Texture2D Texture { get; private set; }
        [Export] public Vector2 SpriteOffset {  get; private set; }
        
        [Export(PropertyHint.Range, "1, 500")] public int ClipSize { get; private set; }
        [Export(PropertyHint.Range, "0.1, 10")] public float ReloadTime { get; private set; }
        [Export(PropertyHint.Range, "100, 2000")] public float KnockbackForce { get; private set; }
        [Export(PropertyHint.Range, "1, 1000")] public float Damage { get; private set; }
        [Export(PropertyHint.Range, "1, 50")] public int BulletCount { get; private set; }
        [Export(PropertyHint.Range, "100, 1000")] public float BulletSpeed { get; private set; }
        [Export(PropertyHint.Range, "0, 45")] public float BulletSpreadDegrees { get; private set; }

    }
}
