namespace Nojumpo.AgentSystem
{
    public class Agent2DDieState : Agent2DState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void StateUpdate() {
            // Prevent State Update
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleAttack() {
            // Prevent Attacking
        }

        protected override void HandleJumpPressed() {
            // Prevent Jumping
        }

        protected override void Agent2DState_OnAnimationEndEvent() {
            animationEventAudio.Play();
            // Call You Died Screen
        }
    }
}