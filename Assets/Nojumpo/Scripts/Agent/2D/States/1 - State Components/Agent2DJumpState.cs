using UnityEngine;

namespace Nojumpo
{
    public class Agent2DJumpState : Agent2DMoveState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float jumpForce = 12.0f;
        [SerializeField] float lowJumpMultiplier = 2.0f;

        bool _jumpInputPressed;

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------

        

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ControlJumpHeight() {
            if (!_jumpInputPressed)
            {
                agent2DMovementData.CurrentVelocity = _agent2D.RigidBody2D.velocity;
                agent2DMovementData.CurrentVelocity.y += lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime ;
                _agent2D.RigidBody2D.velocity = agent2DMovementData.CurrentVelocity;
            }
        }

        void ApplyJump() {
            agent2DMovementData.CurrentVelocity = _agent2D.RigidBody2D.velocity;
            agent2DMovementData.CurrentVelocity.y = jumpForce;
            _agent2D.RigidBody2D.velocity = agent2DMovementData.CurrentVelocity;
            _jumpInputPressed = true;
        }

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleJumpPressed() {
            _jumpInputPressed = true;
        }
        
        protected override void HandleJumpReleased() {
            _jumpInputPressed = false;
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            ApplyJump();
        }

        public override void StateUpdate() {
            ControlJumpHeight();
            CalculateVelocity();
            SetVelocity();

            if (_agent2D.RigidBody2D.velocity.y <= 0)
            {
                _agent2D.ChangeState(fallState);
            }
        }
    }
}
