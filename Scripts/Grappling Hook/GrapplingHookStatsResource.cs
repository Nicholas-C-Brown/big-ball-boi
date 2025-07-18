using Godot;

namespace BigBallBoi.Scripts.Grappling_Hook
{
    public partial class GrapplingHookStatsResource : Resource
    {

        [Export(PropertyHint.Range, "100, 1000")] public float HookLength { get; private set; }

        [Export(PropertyHint.Range, "1, 50")] public float ExtendSpeed { get; private set; }
        [Export(PropertyHint.Range, "1, 50")] public float RetractSpeed { get; private set; }

    }
}
