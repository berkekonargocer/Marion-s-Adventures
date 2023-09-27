using Nojumpo.AudioEventSystem;
using Nojumpo.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    public abstract class Agent2DState : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected InputReader inputReader;

        [SerializeField] protected Agent2DState jumpState;
        [SerializeField] protected Agent2DState fallState;
        [SerializeField] protected Agent2DState climbState;
        [SerializeField] protected Agent2DState attackState;

        [SerializeField] protected string animatorStateParameter = "";

        [SerializeField] protected AudioEventBaseSO animationEventAudio;

        public UnityEvent OnEnter, OnExit;

        protected Agent2D _agent2D;
        protected Agent2DData _agent2DData;

        protected AudioSource animationEventAudioSource;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            animationEventAudioSource = GetComponent<AudioSource>();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void HandleMovement() {
        }

        protected virtual void HandleJumpPressed() {
            if (_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(jumpState);
            }
        }

        protected virtual void HandleJumpReleased() {
        }

        protected virtual void HandleAttack() {
            if (_agent2D.AgentWeapon.CanAttack(_agent2D.GroundDetector.IsGrounded))
            {
                _agent2D.ChangeState(attackState);
            }
        }

        protected bool CheckToChangeIntoFallState() {
            if (!_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(fallState);
                return true;
            }

            return false;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(Agent2D agent2D, Agent2DData agent2DData) {
            _agent2D = agent2D;
            _agent2DData = agent2DData;
        }

        public virtual void Enter() {
            inputReader.onJumpInputPressed += HandleJumpPressed;
            inputReader.onJumpInputReleased += HandleJumpReleased;
            inputReader.onAttackInputPressed += HandleAttack;
            _agent2D.Animator.onAnimationEvent += Agent2DState_OnAnimationEvent;
            _agent2D.Animator.onAnimationEndEvent += Agent2DState_OnAnimationEndEvent;
            _agent2D.Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public virtual void StateUpdate() {
            CheckToChangeIntoFallState();
        }

        public virtual void StateFixedUpdate() {
        }

        public virtual void Agent2DState_OnAnimationEvent() {
            animationEventAudio.Play();
        }

        public virtual void Agent2DState_OnAnimationEndEvent() {
        }

        public virtual void Exit() {
            inputReader.onJumpInputPressed -= HandleJumpPressed;
            inputReader.onJumpInputReleased -= HandleJumpReleased;
            inputReader.onAttackInputPressed -= HandleAttack;
            _agent2D.Animator.onAnimationEvent -= Agent2DState_OnAnimationEvent;
            _agent2D.Animator.onAnimationEndEvent -= Agent2DState_OnAnimationEndEvent;
            OnExit?.Invoke();
        }
    }
}