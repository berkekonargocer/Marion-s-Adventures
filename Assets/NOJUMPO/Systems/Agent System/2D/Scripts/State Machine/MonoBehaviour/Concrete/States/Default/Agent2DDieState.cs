using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DDieState : Agent2DState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void StateUpdate() {
            _agent2D.m_Rigidbody2D.velocity = new Vector2(0, _agent2D.m_Rigidbody2D.velocity.y);
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

        protected override void HandleDie() {
            // Prevent Dying while dying LOL
        }

        protected override void OnAnimationEndEvent() {
            animationEventAudio.Play();

            // Call You Died Screen
        }
    }
}