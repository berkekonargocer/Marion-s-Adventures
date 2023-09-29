namespace Nojumpo.AgentSystem
{
    public class Agent2DGetHitState : Agent2DState
    {
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
            TransitionToIdle();
        }
    }
}