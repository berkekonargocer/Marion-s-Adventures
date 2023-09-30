using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DFallState : Agent2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioEventBaseSO landAudioEvent;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick() {
            HandleMovement();

            if (Mathf.Abs(_agent2D.m_InputReader.MovementVector.y) > 0 && _agent2D.m_ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Climb);

                return;
            }

            if (_agent2D.m_GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Idle);
            }
        }

        public void CheckIfPlayLandSound() {
            if (_agent2D.m_GroundDetector.IsGrounded)
            {
                landAudioEvent.Play();
            }
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            _agent2D.m_Renderer.FaceDirection(_agent2D.m_InputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }
    }
}