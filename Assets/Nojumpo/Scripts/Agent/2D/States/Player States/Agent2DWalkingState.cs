using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DWalkingState : Agent2DStateBase
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected Agent2DMovementData agent2DMovementData;

        [SerializeField] Agent2DStateBase idleState;

        [SerializeField] string animatorStateParameter = "Run";

        [SerializeField] float AccelerationSpeed;
        [SerializeField] float DecelerationSpeed;
        [SerializeField] float MaxSpeed;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            agent2DMovementData = ScriptableObject.CreateInstance<Agent2DMovementData>();
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void CalculateSpeed(Vector2 movementVector, Agent2DMovementData movementData) {
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

        void CalculateHorizontalDirection(Agent2DMovementData movementData) {
            if (InputReader.Instance.MovementVector.x > 0)
            {
                movementData.HorizontalMovementDirection = 1;
            }
            else if (InputReader.Instance.MovementVector.x < 0)
            {
                movementData.HorizontalMovementDirection = -1;
            }
        }

        void CalculateVelocity() {
            CalculateSpeed(InputReader.Instance.MovementVector, agent2DMovementData);
            CalculateHorizontalDirection(agent2DMovementData);
            agent2DMovementData.CurrentVelocity = Vector2.right * (agent2DMovementData.HorizontalMovementDirection * agent2DMovementData.CurrentSpeed);
            agent2DMovementData.CurrentVelocity.y = _agent2D.AgentRigidbody2D.velocity.y;
        }

        void SetVelocity() {
            _agent2D.AgentRigidbody2D.velocity = agent2DMovementData.CurrentVelocity;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            _agent2D.agentAnimator.PlayAnimation(animatorStateParameter);

            agent2DMovementData.HorizontalMovementDirection = 0;
            agent2DMovementData.CurrentSpeed = 0;
            agent2DMovementData.CurrentVelocity = Vector2.zero;
        }

        public override void StateUpdate() {
            base.StateUpdate();
            CalculateVelocity();
            SetVelocity();

            if (Mathf.Abs(_agent2D.AgentRigidbody2D.velocity.x) < 0.01f)
            {
                _agent2D.ChangeState(idleState);
            }
        }
    }
}
