using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DMoveState : Agent2DState
    {
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void Tick() {
            if (CheckToChangeIntoFallState())
                return;

            HandleMovement();

            if (Mathf.Abs(_agent2D.m_InputReader.MovementVector.y) > 0 && _agent2D.m_ClimbableDetector.CanClimb)
            {
                if (_agent2D.m_InputReader.MovementVector.y < 0 && _agent2D.m_GroundDetector.IsGrounded)
                    return;

                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Climb);
                return;
            }

            if (Mathf.Abs(_agent2D.m_Rigidbody2D.velocity.x) < 0.01f)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Idle);
            }
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
            if (_agent2D.m_InputReader.MovementVector.x > 0)
            {
                movementData.HorizontalMovementDirection = 1;
            }
            else if (_agent2D.m_InputReader.MovementVector.x < 0)
            {
                movementData.HorizontalMovementDirection = -1;
            }
        }

        protected void CalculateVelocity() {
            CalculateSpeed(_agent2D.m_InputReader.MovementVector, _agent2D.m_StateFactory.m_AgentMovementData);
            CalculateHorizontalDirection(_agent2D.m_StateFactory.m_AgentMovementData);
            _agent2D.m_StateFactory.m_AgentMovementData.CurrentVelocity = Vector2.right * (_agent2D.m_StateFactory.m_AgentMovementData.HorizontalMovementDirection * _agent2D.m_StateFactory.m_AgentMovementData.CurrentSpeed);

            if (_agent2D.m_Rigidbody2D.velocity.y <= -_agent2DData.m_MaxFallSpeed)
            {
                _agent2D.m_StateFactory.m_AgentMovementData.CurrentVelocity.y = -_agent2DData.m_MaxFallSpeed;
                return;
            }

            _agent2D.m_StateFactory.m_AgentMovementData.CurrentVelocity.y = _agent2D.m_Rigidbody2D.velocity.y;
        }

        protected void SetVelocity() {
            _agent2D.m_Rigidbody2D.velocity = _agent2D.m_StateFactory.m_AgentMovementData.CurrentVelocity;
        }

        protected override void HandleMovement() {
            _agent2D.m_Renderer.FaceDirection(_agent2D.m_InputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void OnAnimationEvent() {
            animationEventAudio.Play();
        }
    }
}