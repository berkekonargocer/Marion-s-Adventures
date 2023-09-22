using UnityEngine;

namespace Nojumpo
{
    public class AgentAnimator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator _agentAnimator;

        public delegate void OnAnimationEvent();
        public OnAnimationEvent onAnimationEvent;

        public delegate void OnAnimationEndEvent();
        public OnAnimationEndEvent onAnimationEndEvent;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            SetComponents();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agentAnimator = GetComponent<Animator>();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void PlayAnimation(string stateName) {
            _agentAnimator.Play(stateName, -1, 0);
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
    }
}