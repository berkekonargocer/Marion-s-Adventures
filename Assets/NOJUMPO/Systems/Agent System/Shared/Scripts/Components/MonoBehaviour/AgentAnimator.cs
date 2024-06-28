using UnityEngine;

namespace Nojumpo
{

    public enum AgentAnimationState
    {
        NONE,
        IDLE,
        WALK,
        RUN,
        JUMP,
        FALL,
        LAND,
        CLIMB,
        ATTACK,
        TAKE_DAMAGE,
        DIE,
    }


    public class AgentAnimator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator _agentAnimator;

        public delegate void OnAnimationEvent();
        public OnAnimationEvent onAnimationEvent;

        public delegate void OnAnimationEndEvent();
        public OnAnimationEndEvent onAnimationEndEvent;

        AgentAnimationState _currentAnimationState;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            SetComponents();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void PlayAnimation(AgentAnimationState state) {
            if (_currentAnimationState == state)
                return;

            if (state == AgentAnimationState.NONE)
                return;

            string stateName = state switch
            {
                AgentAnimationState.IDLE => "Idle",
                AgentAnimationState.WALK => "Walk",
                AgentAnimationState.RUN => "Run",
                AgentAnimationState.JUMP => "Jump",
                AgentAnimationState.FALL => "Fall",
                AgentAnimationState.LAND => "Land",
                AgentAnimationState.CLIMB => "Climb",
                AgentAnimationState.ATTACK => "Attack",
                AgentAnimationState.TAKE_DAMAGE => "TakeDamage",
                AgentAnimationState.DIE => "Die",
                _ => "Idle"
            };

            _agentAnimator.Play(stateName, -1, 0);
            _currentAnimationState = state;
        }



        public void StartAnimation() {
            _agentAnimator.enabled = true;
        }

        public void StopAnimation() {
            _agentAnimator.enabled = false;
        }

        public void InvokeAnimationEvent() {
            onAnimationEvent?.Invoke();
        }

        public void InvokeAnimationEndEvent() {
            onAnimationEndEvent?.Invoke();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agentAnimator = GetComponent<Animator>();
        }
    }
}