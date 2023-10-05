using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player2DIdleState : Player2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] PhysicsMaterial2D normalFrictionMaterial2D;
        [SerializeField] PhysicsMaterial2D noFrictionMaterial2D;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _player2DStateMachine.m_Rigidbody2D.sharedMaterial = normalFrictionMaterial2D;
        }

        public override void Tick(float deltaTime) {
            base.Tick(deltaTime);
            HandleMovement();
        }


        public override void OnExitState() {
            base.OnExitState();
            _player2DStateMachine.m_Rigidbody2D.sharedMaterial = noFrictionMaterial2D;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            if (Mathf.Abs(_player2DStateMachine.m_InputReader.MovementVector.x) > 0)
            {
                _player2DStateMachine.m_Renderer.FaceDirection(_player2DStateMachine.m_InputReader.MovementVector);
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Move);
                return;
            }


            if (Mathf.Abs(_player2DStateMachine.m_InputReader.MovementVector.y) > 0 && _player2DStateMachine.m_ClimbableDetector.CanClimb)
            {
                if (_player2DStateMachine.m_InputReader.MovementVector.y < 0 && _player2DStateMachine.m_GroundDetector.IsGrounded)
                    return;

                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Climb);
            }
        }
    }
}