using Nojumpo.StateMachine;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public abstract class AI2DState : State
    {
        // -------------------------------- FIELDS ---------------------------------
        protected AI2DStateMachine _ai2DStateMachine;
        protected Agent2DData _agent2DData;

        protected float _movementSpeed;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(AI2DStateMachine ai2DStateMachine, Agent2DData agent2DData) {
            _ai2DStateMachine = ai2DStateMachine;
            _agent2DData = agent2DData;
            _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = 1;
        }

        public override void OnEnterState() {
            _ai2DStateMachine.m_Animator.onAnimationEvent += OnAnimationEvent;
            _ai2DStateMachine.m_Animator.onAnimationEndEvent += OnAnimationEndEvent;
            _ai2DStateMachine.m_AgentDamageable.onTakeDamage += OnTakeDamage;
            _ai2DStateMachine.m_AgentDamageable.onDie += OnDie;
            _ai2DStateMachine.m_Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public override void Tick() {
        }

        public override void FixedTick() {
        }

        public override void OnExitState() {
            _ai2DStateMachine.m_Animator.onAnimationEvent -= OnAnimationEvent;
            _ai2DStateMachine.m_Animator.onAnimationEndEvent -= OnAnimationEndEvent;
            _ai2DStateMachine.m_AgentDamageable.onTakeDamage -= OnTakeDamage;
            _ai2DStateMachine.m_AgentDamageable.onDie -= OnDie;
            OnExit?.Invoke();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected void CalculateSpeed(int movementDirection, Agent2DMovementData movementData) {
            if (Mathf.Abs(movementDirection) > 0)
            {
                movementData.CurrentSpeed += _agent2DData.m_AccelerationSpeed * Time.deltaTime;
            }
            else
            {
                movementData.CurrentSpeed -= _agent2DData.m_DecelerationSpeed * Time.deltaTime;
            }

            movementData.CurrentSpeed = Mathf.Clamp(movementData.CurrentSpeed, 0, _movementSpeed);
        }
        

        protected void CalculateVelocity() {
            CalculateSpeed(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection, _ai2DStateMachine.m_AgentMovementData);
            _ai2DStateMachine.m_AgentMovementData.CurrentVelocity = Vector2.right * (_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection * _ai2DStateMachine.m_AgentMovementData.CurrentSpeed);

            if (_ai2DStateMachine.m_Rigidbody2D.velocity.y <= -_agent2DData.m_MaxFallSpeed)
            {
                _ai2DStateMachine.m_AgentMovementData.CurrentVelocity.y = -_agent2DData.m_MaxFallSpeed;
                return;
            }

            _ai2DStateMachine.m_AgentMovementData.CurrentVelocity.y = _ai2DStateMachine.m_Rigidbody2D.velocity.y;
        }

        protected void SetVelocity() {
            _ai2DStateMachine.m_Rigidbody2D.velocity = _ai2DStateMachine.m_AgentMovementData.CurrentVelocity;
        }
        
        protected virtual void CheckIfPathBlocked() {
            if (_ai2DStateMachine.m_AI2DPathBlockDetector.IsPathBlocked)
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection *= -1;
            }
        }

        protected virtual void OnAnimationEvent() {
        }

        protected virtual void OnAnimationEndEvent() {
        }

        protected virtual void HandleMovement() {

        }
        
        protected virtual void HandleTakeDamage() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_TakeDamage);
        }

        protected virtual void HandleDie() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Die);
        }

        protected void TransitionToIdle() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Idle);
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