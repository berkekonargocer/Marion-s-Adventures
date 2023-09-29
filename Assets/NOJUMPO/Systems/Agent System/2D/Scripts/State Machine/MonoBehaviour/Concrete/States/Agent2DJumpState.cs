using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DJumpState : Agent2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        bool _jumpInputPressed;

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            ApplyJump();
        }

        public override void StateUpdate() {
            ControlJumpHeight();
            HandleMovement();

            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.m_ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Climb);
                return;
            }

            if (_agent2D.m_Rigidbody2D.velocity.y <= 0)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Fall);
            }
        }

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            _agent2D.m_Renderer.FaceDirection(inputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void HandleJumpPressed() {
            _jumpInputPressed = true;
        }

        protected override void HandleJumpReleased() {
            _jumpInputPressed = false;
        }

        protected override void Agent2DState_OnAnimationEvent() {
            
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ControlJumpHeight() {
            if (!_jumpInputPressed)
            {
                agent2DMovementData.CurrentVelocity = _agent2D.m_Rigidbody2D.velocity;
                agent2DMovementData.CurrentVelocity.y += _agent2DData.m_LowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
                _agent2D.m_Rigidbody2D.velocity = agent2DMovementData.CurrentVelocity;
            }
        }

        void ApplyJump() {
            agent2DMovementData.CurrentVelocity = _agent2D.m_Rigidbody2D.velocity;
            agent2DMovementData.CurrentVelocity.y = _agent2DData.m_JumpForce;
            _agent2D.m_Rigidbody2D.velocity = agent2DMovementData.CurrentVelocity;
            _jumpInputPressed = true;
        }
    }
}