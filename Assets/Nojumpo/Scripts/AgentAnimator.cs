using UnityEngine;

namespace Nojumpo
{
	public class AgentAnimator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator _characterAnimator;
		
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
			SetComponents();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
	        _characterAnimator = GetComponent<Animator>();
        }
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void PlayAnimation(string stateName) {
	        _characterAnimator.Play(stateName, -1, 0);
        }
    }
}