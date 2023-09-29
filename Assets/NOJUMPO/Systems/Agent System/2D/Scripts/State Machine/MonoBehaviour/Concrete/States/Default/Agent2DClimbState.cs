using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2DClimbState : Agent2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        float _baseGravityScale;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.m_Animator.StopAnimation();
            CacheAgentBaseGravityScale();
            SetAgentGravityScale(0);
            _agent2D.m_Rigidbody2D.velocity = Vector2.zero;
        }

        public override void StateUpdate() {
            if (_agent2D.m_InputReader.MovementVector.magnitude > 0)
            {
                Climb();
            }
            else
            {
                Wait();
            }

            if (!_agent2D.m_ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Idle);
            }
        }

        public override void Exit() {
            base.Exit();
            SetAgentGravityScale(_baseGravityScale);
            _agent2D.m_Animator.StartAnimation();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleJumpPressed() {
            _agent2D.ChangeState(_agent2D.m_StateFactory.m_Jump);
        }

        protected override void HandleAttack() {
            // Prevent Attack While Climbing
        }

        protected override void OnAnimationEvent() {
            animationEventAudio.Play();
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CacheAgentBaseGravityScale() {
            _baseGravityScale = _agent2D.m_Rigidbody2D.gravityScale;
        }

        void SetAgentGravityScale(float gravityScale) {
            _agent2D.m_Rigidbody2D.gravityScale = gravityScale;
        }

        void Climb() {
            _agent2D.m_Animator.StartAnimation();

            if (_agent2D.m_InputReader.MovementVector.y < 0 && _agent2D.m_GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Idle);
                return;
            }

            _agent2D.m_Rigidbody2D.velocity = new Vector2(_agent2D.m_InputReader.MovementVector.x * _agent2DData.m_ClimbingSpeed,
                _agent2D.m_InputReader.MovementVector.y * _agent2DData.m_ClimbingSpeed);
        }

        void Wait() {
            _agent2D.m_Animator.StopAnimation();
            _agent2D.m_Rigidbody2D.velocity = Vector2.zero;
        }
    }
}