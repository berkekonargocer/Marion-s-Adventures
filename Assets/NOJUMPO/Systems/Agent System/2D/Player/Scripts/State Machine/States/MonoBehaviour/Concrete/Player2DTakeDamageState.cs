namespace Nojumpo.AgentSystem
{
    public class Player2DTakeDamageState : Player2DState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick(float deltaTime) {
            // Prevent State Update
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleAttack() {
            // Prevent Attacking
        }

        protected override void HandleJumpPressed() {
            // Prevent Jumping
        }

        protected override void HandleTakeDamage() {
            // Prevent Getting hit
        }

        protected override void OnAnimationEndEvent() {
            TransitionToIdle();
        }
    }
}