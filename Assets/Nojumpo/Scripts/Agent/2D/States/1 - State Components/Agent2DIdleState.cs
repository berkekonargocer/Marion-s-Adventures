using UnityEngine;

namespace Nojumpo
{
    public class Agent2DIdleState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Agent2DStateBase runState;
        [SerializeField] string animatorStateParameter = "Idle";


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            Vector2 moveInput = inputReader.MovementVector;

            if (Mathf.Abs(moveInput.x) > 0)
            {
                _agent2D.ChangeState(runState);
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
