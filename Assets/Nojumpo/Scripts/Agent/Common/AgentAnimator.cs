using UnityEngine;

namespace Nojumpo
{
    public class AgentAnimator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator _agentAnimator;


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
    }
}
