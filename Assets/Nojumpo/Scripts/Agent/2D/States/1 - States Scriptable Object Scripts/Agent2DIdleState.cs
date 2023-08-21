using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Agent2DStateBase walkState;
        [SerializeField] string animatorStateParameter = "Idle";

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            Vector2 moveInput = InputReader.Instance.MovementVector;

            if (Mathf.Abs(moveInput.x) > 0)
            {
                _agent2D.ChangeState(walkState);
            }
        }
        

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            _agent2D.Animator.PlayAnimation(animatorStateParameter);
        }

        public override void StateUpdate() {
            HandleMovement();
        }
    }
}
