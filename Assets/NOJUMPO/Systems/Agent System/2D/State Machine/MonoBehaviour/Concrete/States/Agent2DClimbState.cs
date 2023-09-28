using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DClimbState : Agent2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        float _baseGravityScale;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CacheAgentBaseGravityScale() {
            _baseGravityScale = _agent2D.m_Rigidbody2D.gravityScale;
        }

        void SetAgentGravityScale(float gravityScale) {
            _agent2D.m_Rigidbody2D.gravityScale = gravityScale;
        }

        void Climb() {
            _agent2D.m_Animator.StartAnimation();

            if (inputReader.MovementVector.y < 0 && _agent2D.m_GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.Idle);
                return;
            }

            _agent2D.m_Rigidbody2D.velocity = new Vector2(inputReader.MovementVector.x * _agent2DData.ClimbingSpeed,
                inputReader.MovementVector.y * _agent2DData.ClimbingSpeed);
        }

        void Wait() {
            _agent2D.m_Animator.StopAnimation();
            _agent2D.m_Rigidbody2D.velocity = Vector2.zero;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleJumpPressed() {
            _agent2D.ChangeState(_agent2D.m_StateFactory.Jump);
        }

        protected override void HandleAttack() {
            // Prevent Attack While Climbing
        }

        protected override void Agent2DState_OnAnimationEvent() {
            animationEventAudio.Play();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.m_Animator.StopAnimation();
            CacheAgentBaseGravityScale();
            SetAgentGravityScale(0);
            _agent2D.m_Rigidbody2D.velocity = Vector2.zero;
        }

        public override void StateUpdate() {
            if (inputReader.MovementVector.magnitude > 0)
            {
                Climb();
            }
            else
            {
                Wait();
            }

            if (!_agent2D.m_ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.Idle);
            }
        }

        public override void Exit() {
            base.Exit();
            SetAgentGravityScale(_baseGravityScale);
            _agent2D.m_Animator.StartAnimation();
        }
    }
}