using System;
using UnityEngine;

namespace NOJUMPO
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

        public event Action OnAnimationEvent;
        public event Action OnAnimationEndEvent;

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

            _agentAnimator.Play(state.ToString(), -1, 0);
            _currentAnimationState = state;
        }



        public void StartAnimation() {
            _agentAnimator.enabled = true;
        }

        public void StopAnimation() {
            _agentAnimator.enabled = false;
        }

        public void InvokeAnimationEvent() {
            OnAnimationEvent?.Invoke();
        }

        public void InvokeAnimationEndEvent() {
            OnAnimationEndEvent?.Invoke();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agentAnimator = GetComponent<Animator>();
        }
    }
}