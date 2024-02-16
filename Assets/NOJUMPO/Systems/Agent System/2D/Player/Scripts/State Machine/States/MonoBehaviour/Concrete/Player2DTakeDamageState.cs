namespace Nojumpo.AgentSystem
{
    public class Player2DTakeDamageState : Player2DState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();

            if (_player2DStateMachine.m_AgentDamageable.DamageableHealth.CurrentHealth < 0)
                return;

            StartCoroutine(TransitionToIdleCoroutine(0.1f));
        }

        public override void Tick() {
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
    }
}