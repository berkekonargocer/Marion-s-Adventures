using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DFallState : Agent2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioEventBaseSO landAudioEvent;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        protected override void HandleMovement() {
            _agent2D.AgentRenderer.FaceDirection(inputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        public override void StateUpdate() {
            HandleMovement();

            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(climbState);

                return;
            }

            if (_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(idleState);
            }
        }

        public override void Agent2DState_OnAnimationEvent() {
        }

        public void CheckIfPlayLandSound() {
            if (_agent2D.GroundDetector.IsGrounded)
            {
                landAudioEvent.Play();
            }
        }
    }
}