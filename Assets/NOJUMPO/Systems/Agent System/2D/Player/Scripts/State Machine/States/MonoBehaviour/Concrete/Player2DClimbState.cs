using NOJUMPO.AudioEventSystem;
using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public class Player2DClimbState : Player2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        float _baseGravityScale;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _player2DStateMachine.m_Animator.StopAnimation();
            CacheAgentBaseGravityScale();
            SetAgentGravityScale(0);
            _player2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
        }

        public override void Tick() {
            if (_player2DStateMachine.m_InputReader.MovementVector.magnitude > 0)
            {
                Climb();
            }
            else
            {
                Wait();
            }

            if (!_player2DStateMachine.m_ClimbableDetector.CanClimb)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
            }
        }

        public override void OnExitState() {
            base.OnExitState();
            SetAgentGravityScale(_baseGravityScale);
            _player2DStateMachine.m_Animator.StartAnimation();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleJumpPressed() {
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Jump);
        }

        protected override void HandleAttack() {
            // Prevent Attack While Climbing
        }

        protected override void OnAnimationEvent() {
            animationEventAudio.Play(animationEventAudioSource);
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CacheAgentBaseGravityScale() {
            _baseGravityScale = _player2DStateMachine.m_Rigidbody2D.gravityScale;
        }

        void SetAgentGravityScale(float gravityScale) {
            _player2DStateMachine.m_Rigidbody2D.gravityScale = gravityScale;
        }

        void Climb() {
            _player2DStateMachine.m_Animator.StartAnimation();

            if (_player2DStateMachine.m_InputReader.MovementVector.y < 0 && _player2DStateMachine.m_GroundDetector.IsGrounded)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
                return;
            }

            _player2DStateMachine.m_Rigidbody2D.velocity = new Vector2(_player2DStateMachine.m_InputReader.MovementVector.x * _agent2DData.m_ClimbingSpeed,
                _player2DStateMachine.m_InputReader.MovementVector.y * _agent2DData.m_ClimbingSpeed);
        }

        void Wait() {
            _player2DStateMachine.m_Animator.StopAnimation();
            _player2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
        }
    }
}