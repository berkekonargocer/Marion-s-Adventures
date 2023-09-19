using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DStateBase moveState;
        [SerializeField] PhysicsMaterial2D normalFrictionMaterial2D;
        [SerializeField] PhysicsMaterial2D noFrictionMaterial2D;
        

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            if (Mathf.Abs(inputReader.MovementVector.x) > 0)
            {
                _agent2D.ChangeState(moveState);
                return;
            }


            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.ClimbableDetector.CanClimb)
            {
                if (inputReader.MovementVector.y < 0 && _agent2D.GroundDetector.IsGrounded)
                    return;

                _agent2D.ChangeState(climbState);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.RigidBody2D.sharedMaterial = normalFrictionMaterial2D;
            _agent2D.RigidBody2D.velocity = Vector2.zero; // Find a better way to solve sliding problem
        }

        public override void StateUpdate() {
            base.StateUpdate();
            HandleMovement();
        }

        public override void Agent2DState_OnAnimationEvent() {
            
        }

        public override void Exit() {
            base.Exit();
            _agent2D.RigidBody2D.sharedMaterial = noFrictionMaterial2D;
        }
    }
}