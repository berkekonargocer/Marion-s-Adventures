using Nojumpo.AudioEventSystem;
using Nojumpo.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    [RequireComponent(typeof(StateFactory))]
    public abstract class Agent2DState : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected InputReader inputReader;
        
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

        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(Agent2D agent2D, Agent2DData agent2DData) {
            _agent2D = agent2D;
            _agent2DData = agent2DData;
        }

        public virtual void Enter() {
            inputReader.onJumpInputPressed += HandleJumpPressed;
            inputReader.onJumpInputReleased += HandleJumpReleased;
            inputReader.onAttackInputPressed += HandleAttack;
            _agent2D.m_Animator.onAnimationEvent += Agent2DState_OnAnimationEvent;
            _agent2D.m_Animator.onAnimationEndEvent += Agent2DState_OnAnimationEndEvent;
            _agent2D.m_Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public virtual void StateUpdate() {
            CheckToChangeIntoFallState();
        }

        public virtual void StateFixedUpdate() {
        }

        protected virtual void Agent2DState_OnAnimationEvent() {
            
        }

        protected virtual void Agent2DState_OnAnimationEndEvent() {
        }

        public virtual void Exit() {
            inputReader.onJumpInputPressed -= HandleJumpPressed;
            inputReader.onJumpInputReleased -= HandleJumpReleased;
            inputReader.onAttackInputPressed -= HandleAttack;
            _agent2D.m_Animator.onAnimationEvent -= Agent2DState_OnAnimationEvent;
            _agent2D.m_Animator.onAnimationEndEvent -= Agent2DState_OnAnimationEndEvent;
            OnExit?.Invoke();
        }
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void HandleMovement() {
        }

        protected virtual void HandleJumpPressed() {
            if (_agent2D.m_GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Jump);
            }
        }

        protected virtual void HandleJumpReleased() {
        }

        protected virtual void HandleAttack() {
            if (_agent2D.m_AgentWeapon.CanAttack(_agent2D.m_GroundDetector.IsGrounded))
            {
                _agent2D.ChangeState(_agent2D.m_StateFactory.m_Attack);
            }
        }

        protected bool CheckToChangeIntoFallState() {
            if (_agent2D.m_GroundDetector.IsGrounded)
                return false;

            _agent2D.ChangeState(_agent2D.m_StateFactory.m_Fall);
            return true;
        }
    }
}