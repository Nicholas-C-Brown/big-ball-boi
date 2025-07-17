using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBallBoiGame.State.ShotgunStates
{
    public partial class ShotgunState : State<Shotgun>
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
