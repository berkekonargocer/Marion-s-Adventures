using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DMoveState : Agent2DState
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected Agent2DMovementData agent2DMovementData;


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void StateUpdate() {
            if (CheckToChangeIntoFallState())
                return;

            HandleMovement();

            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.m_ClimbableDetector.CanClimb)
            {
                if (inputReader.MovementVector.y < 0 && _agent2D.m_GroundDetector.IsGrounded)
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
                movementData.CurrentSpeed += _agent2DData.AccelerationSpeed * Time.deltaTime;
            }
            else
            {
                movementData.CurrentSpeed -= _agent2DData.DecelerationSpeed * Time.deltaTime;
            }

            movementData.CurrentSpeed = Mathf.Clamp(movementData.CurrentSpeed, 0, _agent2DData.MaxSpeed);
        }

        protected void CalculateHorizontalDirection(Agent2DMovementData movementData) {
            if (inputReader.MovementVector.x > 0)
            {
                movementData.HorizontalMovementDirection = 1;
            }
            else if (inputReader.MovementVector.x < 0)
            {
                movementData.HorizontalMovementDirection = -1;
            }
        }

        protected void CalculateVelocity() {
            CalculateSpeed(inputReader.MovementVector, agent2DMovementData);
            CalculateHorizontalDirection(agent2DMovementData);
            agent2DMovementData.CurrentVelocity = Vector2.right * (agent2DMovementData.HorizontalMovementDirection * agent2DMovementData.CurrentSpeed);

            if (_agent2D.m_Rigidbody2D.velocity.y <= -_agent2DData.MaxFallSpeed)
            {
                agent2DMovementData.CurrentVelocity.y = -_agent2DData.MaxFallSpeed;
                return;
            }

            agent2DMovementData.CurrentVelocity.y = _agent2D.m_Rigidbody2D.velocity.y;
        }

        protected void SetVelocity() {
            _agent2D.m_Rigidbody2D.velocity = agent2DMovementData.CurrentVelocity;
        }

        protected override void HandleMovement() {
            _agent2D.m_Renderer.FaceDirection(inputReader.MovementVector);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void Agent2DState_OnAnimationEvent() {
            animationEventAudio.Play();
        }
    }
}