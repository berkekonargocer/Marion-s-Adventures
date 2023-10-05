using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player2DFallState : Player2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioEventBaseSO landAudioEvent;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick(float deltaTime) {
            HandleMovement();

            if (Mathf.Abs(_player2DStateMachine.m_InputReader.MovementVector.y) > 0 && _player2DStateMachine.m_ClimbableDetector.CanClimb)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Climb);

                return;
            }

            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
            }
        }

        public void CheckIfPlayLandSound() {
            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
            {
                landAudioEvent.Play();
            }
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            _player2DStateMachine.m_Renderer.FaceDirection(_player2DStateMachine.m_InputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }
    }
}