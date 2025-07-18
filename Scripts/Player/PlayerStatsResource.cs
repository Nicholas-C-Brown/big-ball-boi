using Godot;

namespace BigBallBoi.Scripts.Player
{
    public partial class PlayerStatsResource : Resource
    {

        [Export(PropertyHint.Range, "100, 1000")] public float JumpStrength { get; private set; }

        [Export(PropertyHint.Range, "100, 2000")] public float MovementForce { get; private set; }
        [Export(PropertyHint.Range, "100, 500")] public float MaxAppliedMovementSpeed { get; private set; }

        [Export(PropertyHint.Range, "100, 2000")] public float HookedMovementForce { get; private set; }
        [Export(PropertyHint.Range, "100, 3000")] public float UpwardsReelingForce { get; private set; }
        [Export(PropertyHint.Range, "100, 500")] public float DownwardsReelingForce { get; private set; }

    }
}
