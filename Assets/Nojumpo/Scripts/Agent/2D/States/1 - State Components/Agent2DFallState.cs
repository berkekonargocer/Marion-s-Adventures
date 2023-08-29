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

            if (_agent2D.GroundDetector.IsGrounded)
            {
                if (inputReader.MovementVector.x != 0)
                {
                    _agent2D.ChangeState(moveState);
                    return;
                }
                
                _agent2D.ChangeState(idleState);
            }
        }
    }
}
