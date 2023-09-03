using UnityEngine;

namespace Nojumpo
{
    public class Agent2DFallState : Agent2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void StateUpdate() {
            CalculateVelocity();
            SetVelocity();

            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(climbState);

                return;
            }

            if (_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(idleState);
            }
        }
    }
}