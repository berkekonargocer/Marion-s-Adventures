using Nojumpo.AgentSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.StateMachine
{
    public abstract class State : MonoBehaviour, IState
    {
        // -------------------------------- FIELDS ---------------------------------
        [Space]
        [SerializeField] protected string animatorStateParameter = "";
        [Space]
        public UnityEvent OnEnter, OnExit;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public abstract void OnEnterState();
        public abstract void Tick();
        public abstract void FixedTick();
        public abstract void OnExitState();
        
        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void EnterSetup(Agent2D agent2D) {
            agent2D.m_Animator.onAnimationEvent += OnAnimationEvent;
            agent2D.m_Animator.onAnimationEndEvent += OnAnimationEndEvent;
            agent2D.m_AgentDamageable.onTakeDamage += OnTakeDamage;
            agent2D.m_AgentDamageable.onDie += OnDie;

            if (!string.IsNullOrEmpty(animatorStateParameter))
            {
                agent2D.m_Animator.PlayAnimation(animatorStateParameter);
            }
            
            OnEnter?.Invoke();
        }

        protected virtual void ExitSetup(Agent2D agent2D) {
            agent2D.m_Animator.onAnimationEvent -= OnAnimationEvent;
            agent2D.m_Animator.onAnimationEndEvent -= OnAnimationEndEvent;
            agent2D.m_AgentDamageable.onTakeDamage -= OnTakeDamage;
            agent2D.m_AgentDamageable.onDie -= OnDie;
            
            OnExit?.Invoke();
        }
        
        protected virtual void OnAnimationEvent() {
        }

        protected virtual void OnAnimationEndEvent() {
        }
        
        protected virtual void OnTakeDamage() {
        }

        protected virtual void OnDie() {
        }
    }
}