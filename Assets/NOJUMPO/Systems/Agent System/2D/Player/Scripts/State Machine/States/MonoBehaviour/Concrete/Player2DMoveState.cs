using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player2DMoveState : Player2DState
    {
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void Tick(float deltaTime) {
            if (CheckIfChangeIntoFallState())
                return;

            HandleMovement();

            if (TryClimb())
                return;

            CheckVelocityToChangeIntoIdle();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected void CalculateSpeed(Vector2 movementVector, Agent2DMovementData movementData) {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.CurrentSpeed += _agent2DData.m_AccelerationSpeed * Time.deltaTime;
            }
            else
            {
                movementData.CurrentSpeed -= _agent2DData.m_DecelerationSpeed * Time.deltaTime;
            }

            movementData.CurrentSpeed = Mathf.Clamp(movementData.CurrentSpeed, 0, _agent2DData.m_MaxSpeed);
        }

        protected void CalculateHorizontalDirection(Agent2DMovementData movementData) {
            if (_player2DStateMachine.m_InputReader.MovementVector.x > 0)
            {
                movementData.HorizontalMovementDirection = 1;
            }
            else if (_player2DStateMachine.m_InputReader.MovementVector.x < 0)
            {
                movementData.HorizontalMovementDirection = -1;
            }
        }

        protected void CalculateVelocity() {
            CalculateSpeed(_player2DStateMachine.m_InputReader.MovementVector, _player2DStateMachine.m_AgentMovementData);
            CalculateHorizontalDirection(_player2DStateMachine.m_AgentMovementData);
            _player2DStateMachine.m_AgentMovementData.CurrentVelocity = Vector2.right * (_player2DStateMachine.m_AgentMovementData.HorizontalMovementDirection * _player2DStateMachine.m_AgentMovementData.CurrentSpeed);

            if (_player2DStateMachine.m_Rigidbody2D.velocity.y <= -_agent2DData.m_MaxFallSpeed)
            {
                _player2DStateMachine.m_AgentMovementData.CurrentVelocity.y = -_agent2DData.m_MaxFallSpeed;
                return;
            }

            _player2DStateMachine.m_AgentMovementData.CurrentVelocity.y = _player2DStateMachine.m_Rigidbody2D.velocity.y;
        }

        protected void SetVelocity() {
            _player2DStateMachine.m_Rigidbody2D.velocity = _player2DStateMachine.m_AgentMovementData.CurrentVelocity;
        }

        protected override void HandleMovement() {
            _player2DStateMachine.m_Renderer.FaceDirection(_player2DStateMachine.m_InputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void OnAnimationEvent() {
            if (animationEventAudio != null)
            {
                animationEventAudio.Play();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        bool TryClimb() {
            if (Mathf.Abs(_player2DStateMachine.m_InputReader.MovementVector.y) > 0 && _player2DStateMachine.m_ClimbableDetector.CanClimb)
            {
                if (_player2DStateMachine.m_InputReader.MovementVector.y < 0 && _player2DStateMachine.m_GroundDetector.IsGrounded)
                    return true;

                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Climb);
                return true;
            }

            return false;
        }

        void CheckVelocityToChangeIntoIdle() {
            if (Mathf.Abs(_player2DStateMachine.m_Rigidbody2D.velocity.x) < 0.01f)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
            }
        }
    }
}