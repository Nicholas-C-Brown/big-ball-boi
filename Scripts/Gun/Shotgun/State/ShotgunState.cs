using BigBallBoiGame.State;
using Godot;

namespace BigBallBoiGame.Scripts.Gun.Shotgun.State
{
    public partial class ShotgunState : State<ShotgunNode>
    {

        protected void LookAtMouse()
        {
            Vector2 mousePosition = Parent.GetGlobalMousePosition();
            Parent.LookAt(mousePosition);
        }

        protected void HandleSpriteFlip()
        {

            Vector2 mousePosition = Parent.GetGlobalMousePosition();

            if (mousePosition < Parent.GlobalPosition)
            {
                Parent.Sprite.FlipV = true;
            }
            else if (mousePosition > Parent.GlobalPosition)
            {
                Parent.Sprite.FlipV = false;
            }

        }

    }
}
