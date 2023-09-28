using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DIdleState : Agent2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] PhysicsMaterial2D normalFrictionMaterial2D;
        [SerializeField] PhysicsMaterial2D noFrictionMaterial2D;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.m_Rigidbody2D.sharedMaterial = normalFrictionMaterial2D;
            _agent2D.m_Rigidbody2D.velocity = Vector2.zero; // Find a better way to solve sliding problem
        }

        public override void StateUpdate() {
            base.StateUpdate();
            HandleMovement();
        }


        public override void Exit() {
            base.Exit();
            _agent2D.m_Rigidbody2D.sharedMaterial = noFrictionMaterial2D;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            if (Mathf.Abs(inputReader.MovementVector.x) > 0)
            {
                _agent2D.m_Renderer.FaceDirection(inputReader.MovementVector);
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Move);
                return;
            }


            if (Mathf.Abs(inputReader.MovementVector.y) > 0 && _agent2D.m_ClimbableDetector.CanClimb)
            {
                if (inputReader.MovementVector.y < 0 && _agent2D.m_GroundDetector.IsGrounded)
                    return;

                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Climb);
            }
        }
    }
}