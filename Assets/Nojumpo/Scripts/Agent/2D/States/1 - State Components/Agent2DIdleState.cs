using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Agent2DStateBase moveState;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------

        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement(Vector2 movementVector) {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                _agent2D.ChangeState(moveState);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            // agent2DMovementData.HorizontalMovementDirection = 0;
            // agent2DMovementData.CurrentSpeed = 0;
            // agent2DMovementData.CurrentVelocity = Vector2.zero;
        }
        public override void StateUpdate() {
            HandleMovement(inputReader.MovementVector);
        }
    }
}
