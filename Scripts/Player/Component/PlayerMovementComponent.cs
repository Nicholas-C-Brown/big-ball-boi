using Godot;

namespace BigBallBoiGame.Scripts.Player.Component
{

    public partial class PlayerMovementComponent : Node
    {

        [Export(PropertyHint.Range, "100, 1000")] private float jumpStrength;

        [Export(PropertyHint.Range, "100, 2000")] private float movementForce;
        [Export(PropertyHint.Range, "100, 500")] private float maxMoveSpeed;

        [Export(PropertyHint.Range, "100, 2000")] private float hookedMovementForce;
        [Export(PropertyHint.Range, "100, 3000")] private float upwardsReelingForce;
        [Export(PropertyHint.Range, "100, 3000")] private float downwardsReelingForce;

   

        public float GetJumpStrength()
        {
            return -jumpStrength;
        }

        public float GetMovementForce()
        {
            return movementForce;
        }

        public float GetMaxMovementSpeed()
        {
            return maxMoveSpeed;
        }

        public float GetHookedMovementForce()
        {
            return hookedMovementForce;
        }

        public float GetUpwardsReelingForce()
        {
            return upwardsReelingForce;
        }

        public float GetDownwardsReelingForce()
        {
            return -downwardsReelingForce;
        }



    }

}

    
