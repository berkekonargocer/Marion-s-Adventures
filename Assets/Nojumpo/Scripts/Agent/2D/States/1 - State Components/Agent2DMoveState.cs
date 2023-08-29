using UnityEngine;

namespace Nojumpo
{
    public class Agent2DMoveState : Agent2DStateBase
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected Agent2DStateBase idleState;
        [SerializeField] protected Agent2DMovementData agent2DMovementData;
        
        [SerializeField] float AccelerationSpeed;
        [SerializeField] float DecelerationSpeed;
        [SerializeField] float MaxSpeed;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------



        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        
        
        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected void CalculateSpeed(Vector2 movementVector, Agent2DMovementData movementData) {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.CurrentSpeed += AccelerationSpeed * Time.deltaTime;
            }
            else
            {
                movementData.CurrentSpeed -= DecelerationSpeed * Time.deltaTime;
            }

            movementData.CurrentSpeed = Mathf.Clamp(movementData.CurrentSpeed, 0, MaxSpeed);
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
            agent2DMovementData.CurrentVelocity.y = _agent2D.RigidBody2D.velocity.y;
        }

        protected void SetVelocity() {
            _agent2D.RigidBody2D.velocity = agent2DMovementData.CurrentVelocity;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void StateUpdate() {
            base.StateUpdate();
            CalculateVelocity();
            SetVelocity();

            if (Mathf.Abs(_agent2D.RigidBody2D.velocity.x) < 0.01f)
            {
                _agent2D.ChangeState(idleState);
            }
        }
    }
}
