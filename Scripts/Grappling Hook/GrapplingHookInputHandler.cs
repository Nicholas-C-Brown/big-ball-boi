using BigBallBoi.Scripts.Input;
using Godot;

public partial class GrapplingHookInputHandler : Node
{

    public bool WantsToExtendHook()
    {
        return Input.IsActionJustPressed(Actions.HOOK_ACTION);
    }

    public bool WantsToRetractHook()
    {
        return Input.IsActionJustReleased(Actions.HOOK_ACTION);
    }

}
