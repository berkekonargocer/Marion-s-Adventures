using UnityEngine;

namespace Nojumpo
{
    public class Agent2DClimbState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Agent2DStateBase idleState;

        float _baseGravityScale;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void OnEnable() {
            // TO DON'T SUBSCRIBE TO onJumpInputPressed AND onJumpInputReleased EVENT
        }

        protected override void OnDisable() {
            // TO DON'T SUBSCRIBE TO onJumpInputPressed AND onJumpInputReleased EVENT
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CacheAgentBaseGravityScale() {
            _baseGravityScale = _agent2D.RigidBody2D.gravityScale;
        }

        void SetAgentGravityScale(float gravityScale) {
            _agent2D.RigidBody2D.gravityScale = gravityScale;
        }

        void Climb() {
            _agent2D.Animator.StartAnimation();

            if (inputReader.MovementVector.y < 0 && _agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(idleState);
                return;
            }

            _agent2D.RigidBody2D.velocity = new Vector2(inputReader.MovementVector.x * _agent2DData.ClimbingSpeed,
                inputReader.MovementVector.y * _agent2DData.ClimbingSpeed);
        }

        void Wait() {
            _agent2D.Animator.StopAnimation();
            _agent2D.RigidBody2D.velocity = Vector2.zero;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleJumpPressed() {
            _agent2D.ChangeState(jumpState);
            Debug.Log("HANDLE JUMP PRESSED", gameObject);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.Animator.StopAnimation();
            CacheAgentBaseGravityScale();
            SetAgentGravityScale(0);
            _agent2D.RigidBody2D.velocity = Vector2.zero;
            inputReader.onJumpInputPressed -= base.HandleJumpPressed;
            inputReader.onJumpInputPressed += HandleJumpPressed;
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

            if (!_agent2D.ClimbableDetector.CanClimb)
            {
                _agent2D.ChangeState(idleState);
            }
        }

        public override void Exit() {
            SetAgentGravityScale(_baseGravityScale);
            _agent2D.Animator.StartAnimation();
            inputReader.onJumpInputPressed += base.HandleJumpPressed;
            inputReader.onJumpInputPressed -= HandleJumpPressed;
        }
    }
}
