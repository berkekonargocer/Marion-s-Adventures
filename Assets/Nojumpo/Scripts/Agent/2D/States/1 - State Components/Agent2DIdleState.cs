using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------

        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            if (Mathf.Abs(inputReader.MovementVector.x) > 0)
            {
                _agent2D.ChangeState(moveState);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.RigidBody2D.velocity = Vector2.zero; // Find a better way to solve sliding problem
        }

        public override void StateUpdate() {
            HandleMovement();
            
            if (_agent2D.RigidBody2D.velocity.y < 0)
            {
                _agent2D.ChangeState(fallState);
            }
        }
    }
}
