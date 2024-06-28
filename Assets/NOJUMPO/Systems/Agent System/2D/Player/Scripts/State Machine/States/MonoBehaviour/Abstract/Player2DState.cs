using System.Collections;
using Nojumpo.AudioEventSystem;
using Nojumpo.StateMachine;
using Nojumpo.Utils;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    [RequireComponent(typeof(Player2DStateFactory))]
    public abstract class Player2DState : State
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected AudioEventBaseSO animationEventAudio;

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

        public override void OnEnterState() {
            EnterSetup(_player2DStateMachine);
            _player2DStateMachine.m_InputReader.OnJumpInputPressed += HandleJumpPressed;
            _player2DStateMachine.m_InputReader.OnJumpInputReleased += HandleJumpReleased;
            _player2DStateMachine.m_InputReader.OnAttackInputPressed += HandleAttack;
        }

        public override void Tick() {
            CheckIfChangeIntoFallState();
        }

        public override void FixedTick() {
            
        }

        public override void OnExitState() {
            ExitSetup(_player2DStateMachine);
            _player2DStateMachine.m_InputReader.OnJumpInputPressed -= HandleJumpPressed;
            _player2DStateMachine.m_InputReader.OnJumpInputReleased -= HandleJumpReleased;
            _player2DStateMachine.m_InputReader.OnAttackInputPressed -= HandleAttack;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void OnAnimationEvent() {
        }

        protected override void OnAnimationEndEvent() {
        }

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

        protected bool CheckIfChangeIntoFallState() {
            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
                return false;

            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Fall);
            return true;
        }

        protected void TransitionToIdle() {
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
        }

        protected IEnumerator TransitionToIdleCoroutine(float transitionDelay) {
            yield return NJUtils.GetWait(transitionDelay);
            
            _player2DStateMachine.ChangeState(_player2DStateMachine.m_StateFactory.m_Idle);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        protected override void OnTakeDamage() {
            HandleTakeDamage();
        }

        protected override void OnDie() {
            HandleDie();
        }
    }
}