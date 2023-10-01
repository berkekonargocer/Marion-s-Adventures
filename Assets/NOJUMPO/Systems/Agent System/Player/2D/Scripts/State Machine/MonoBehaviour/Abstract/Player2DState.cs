using Nojumpo.AudioEventSystem;
using Nojumpo.Interfaces;
using Nojumpo.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    [RequireComponent(typeof(Player2DStateFactory))]
    public abstract class Player2DState : MonoBehaviour, IState
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected string animatorStateParameter = "";
        [SerializeField] protected AudioEventBaseSO animationEventAudio;

        public UnityEvent OnEnter, OnExit;

        protected Player2DStateMachine _player2DStateMachine;
        protected Agent2DData _agent2DData;

        protected AudioSource animationEventAudioSource;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            animationEventAudioSource = GetComponent<AudioSource>();
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(Player2DStateMachine player2DStateMachine, Agent2DData agent2DData) {
            _player2DStateMachine = player2DStateMachine;
            _agent2DData = agent2DData;
        }

        public virtual void OnEnterState() {
            _player2DStateMachine.m_InputReader.onJumpInputPressed += HandleJumpPressed;
            _player2DStateMachine.m_InputReader.onJumpInputReleased += HandleJumpReleased;
            _player2DStateMachine.m_InputReader.onAttackInputPressed += HandleAttack;
            _player2DStateMachine.m_Animator.onAnimationEvent += OnAnimationEvent;
            _player2DStateMachine.m_Animator.onAnimationEndEvent += OnAnimationEndEvent;
            _player2DStateMachine.m_AgentDamageable.onTakeDamage += OnTakeDamage;
            _player2DStateMachine.m_AgentDamageable.onDie += OnDie;
            _player2DStateMachine.m_Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public virtual void Tick() {
            CheckToChangeIntoFallState();
        }

        public virtual void FixedTick() {
        }

        protected virtual void OnAnimationEvent() {
        }

        protected virtual void OnAnimationEndEvent() {
        }

        public virtual void OnExitState() {
            _player2DStateMachine.m_InputReader.onJumpInputPressed -= HandleJumpPressed;
            _player2DStateMachine.m_InputReader.onJumpInputReleased -= HandleJumpReleased;
            _player2DStateMachine.m_InputReader.onAttackInputPressed -= HandleAttack;
            _player2DStateMachine.m_Animator.onAnimationEvent -= OnAnimationEvent;
            _player2DStateMachine.m_Animator.onAnimationEndEvent -= OnAnimationEndEvent;
            _player2DStateMachine.m_AgentDamageable.onTakeDamage -= OnTakeDamage;
            _player2DStateMachine.m_AgentDamageable.onDie -= OnDie;
            OnExit?.Invoke();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void HandleMovement() {
        }

        protected virtual void HandleJumpPressed() {
            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Jump);
            }
        }

        protected virtual void HandleJumpReleased() {
        }

        protected virtual void HandleAttack() {
            if (_player2DStateMachine.m_AgentWeapon.CanAttack(_player2DStateMachine.m_GroundDetector.IsGrounded))
            {
                _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Attack);
            }
        }

        protected virtual void HandleTakeDamage() {
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_TakeDamage);
        }

        protected virtual void HandleDie() {
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Die);
        }

        protected bool CheckToChangeIntoFallState() {
            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
                return false;

            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Fall);
            return true;
        }

        protected void TransitionToIdle() {
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
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