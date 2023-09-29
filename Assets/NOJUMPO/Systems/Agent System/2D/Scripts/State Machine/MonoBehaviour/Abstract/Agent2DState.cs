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
            _agent2D.m_InputReader.onJumpInputPressed += HandleJumpPressed;
            _agent2D.m_InputReader.onJumpInputReleased += HandleJumpReleased;
            _agent2D.m_InputReader.onAttackInputPressed += HandleAttack;
            _agent2D.m_Animator.onAnimationEvent += OnAnimationEvent;
            _agent2D.m_Animator.onAnimationEndEvent += OnAnimationEndEvent;
            _agent2D.m_AgentDamageable.onTakeDamage += OnTakeDamage;
            _agent2D.m_AgentDamageable.onDie += OnDie;
            _agent2D.m_Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public virtual void StateUpdate() {
            CheckToChangeIntoFallState();
        }

        public virtual void StateFixedUpdate() {
        }

        protected virtual void OnAnimationEvent() {
        }

        protected virtual void OnAnimationEndEvent() {
        }

        public virtual void Exit() {
            _agent2D.m_InputReader.onJumpInputPressed -= HandleJumpPressed;
            _agent2D.m_InputReader.onJumpInputReleased -= HandleJumpReleased;
            _agent2D.m_InputReader.onAttackInputPressed -= HandleAttack;
            _agent2D.m_Animator.onAnimationEvent -= OnAnimationEvent;
            _agent2D.m_Animator.onAnimationEndEvent -= OnAnimationEndEvent;
            _agent2D.m_AgentDamageable.onTakeDamage -= OnTakeDamage;
            _agent2D.m_AgentDamageable.onDie -= OnDie;
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

        protected virtual void HandleTakeDamage() {
            _agent2D.ChangeState(_agent2D.m_StateFactory.m_TakeDamage);
        }

        protected virtual void HandleDie() {
            _agent2D.ChangeState(_agent2D.m_StateFactory.m_Die);
        }

        protected bool CheckToChangeIntoFallState() {
            if (_agent2D.m_GroundDetector.IsGrounded)
                return false;

            _agent2D.ChangeState(_agent2D.m_StateFactory.m_Fall);
            return true;
        }

        protected void TransitionToIdle() {
            _agent2D.ChangeState(_agent2D.m_StateFactory.m_Idle);
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void OnTakeDamage() {
            HandleTakeDamage();
        }

        void OnDie() {
            HandleDie();
        }
    }
}