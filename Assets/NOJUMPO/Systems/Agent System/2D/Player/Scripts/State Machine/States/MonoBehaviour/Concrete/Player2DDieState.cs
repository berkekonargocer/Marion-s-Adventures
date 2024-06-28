using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public class Player2DDieState : Player2DState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick() {
            _player2DStateMachine.m_Rigidbody2D.velocity = new Vector2(0, _player2DStateMachine.m_Rigidbody2D.velocity.y);
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
            if (animationEventAudio != null)
            {
                animationEventAudio.Play(animationEventAudioSource);
            }

            // Call You Died Screen
        }
    }
}