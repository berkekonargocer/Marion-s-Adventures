using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Agent2DStateBase walkingState;
        [SerializeField] string animatorStateParameter = "Idle";

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            _agent2D.agentAnimator.PlayAnimation(animatorStateParameter);
        }

        protected override void HandleMovement() {
            Vector2 moveInput = InputReader.Instance.MovementVector;

            if (Mathf.Abs(moveInput.x) > 0)
            {
                _agent2D.ChangeState(walkingState);
            }
        }

        public override void StateUpdate() {
            HandleMovement();
        }
    }
}
