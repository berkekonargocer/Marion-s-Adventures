using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player2DJumpState : Player2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        bool _jumpInputPressed;

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            ApplyJump();
        }

        public override void Tick() {
            ControlJumpHeight();
            HandleMovement();

            if (Mathf.Abs(_player2DStateMachine.m_InputReader.MovementVector.y) > 0 && _player2DStateMachine.m_ClimbableDetector.CanClimb)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Climb);
                return;
            }

            if (_player2DStateMachine.m_Rigidbody2D.velocity.y <= 0)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Fall);
            }
        }

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            _player2DStateMachine.m_Renderer.FaceDirection(_player2DStateMachine.m_InputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void HandleJumpPressed() {
            _jumpInputPressed = true;
        }

        protected override void HandleJumpReleased() {
            _jumpInputPressed = false;
        }

        protected override void OnAnimationEvent() {
            
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ControlJumpHeight() {
            if (!_jumpInputPressed)
            {
                _player2DStateMachine.m_AgentMovementData.CurrentVelocity = _player2DStateMachine.m_Rigidbody2D.velocity;
                _player2DStateMachine.m_AgentMovementData.CurrentVelocity.y += _agent2DData.m_LowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
                _player2DStateMachine.m_Rigidbody2D.velocity = _player2DStateMachine.m_AgentMovementData.CurrentVelocity;
            }
        }

        void ApplyJump() {
            _player2DStateMachine.m_AgentMovementData.CurrentVelocity = _player2DStateMachine.m_Rigidbody2D.velocity;
            _player2DStateMachine.m_AgentMovementData.CurrentVelocity.y = _agent2DData.m_JumpForce;
            _player2DStateMachine.m_Rigidbody2D.velocity = _player2DStateMachine.m_AgentMovementData.CurrentVelocity;
            _jumpInputPressed = true;
        }
    }
}