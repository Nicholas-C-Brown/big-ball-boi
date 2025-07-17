using BigBallBoi.Scripts.Input;
using Godot;

namespace BigBallBoiGame.Scripts.Gun
{

    public partial class GunInputHandler : Node
    {

        public bool WantsToShoot()
        {
            return Input.IsActionJustPressed(Actions.SHOOT_ACTION);
        }

        public bool WantsToReload()
        {
            return Input.IsActionJustPressed(Actions.RELOAD_ACTION);
        }

    }

}
