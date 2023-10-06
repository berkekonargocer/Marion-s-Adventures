using Nojumpo.StateMachine;

namespace Nojumpo.AgentSystem
{
    public abstract class AI2DState : State
    {
        // -------------------------------- FIELDS ---------------------------------
        AI2DStateMachine _ai2DStateMachine;
        Agent2DData _agent2DData;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(AI2DStateMachine ai2DStateMachine, Agent2DData agent2DData) {
            _ai2DStateMachine = ai2DStateMachine;
            _agent2DData = agent2DData;
        }
        
        public override void OnEnterState() {
            _ai2DStateMachine.m_Animator.onAnimationEvent += OnAnimationEvent;
            _ai2DStateMachine.m_Animator.onAnimationEndEvent += OnAnimationEndEvent;
            _ai2DStateMachine.m_AgentDamageable.onTakeDamage += OnTakeDamage;
            _ai2DStateMachine.m_AgentDamageable.onDie += OnDie;
            _ai2DStateMachine.m_Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();

        }

        public override void Tick(float deltaTime) {
            
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
        protected virtual void OnAnimationEvent() {
        }

        protected virtual void OnAnimationEndEvent() {
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