using UnityEngine;

namespace Nojumpo
{
    public class Agent2DWalkingState : Agent2DStateBase
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected Agent2DMovementData agent2DMovementData;

        [SerializeField] Agent2DStateBase idleState;
        
        [SerializeField] string animatorStateParameter = "Run";
        

        protected virtual void Awake() {
            this.agent2DMovementData = GetComponentInParent<Agent2DMovementData>();
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void EnterState() {
            _agent2D.agentAnimator.PlayAnimation(this.animatorStateParameter);
        }

        public override void Update() {
            HandleMovement();
        }

        protected override void HandleMovement() {
            Vector2 moveInput = this.agent2DMovementData.iMovementControlType.MovementInput();

            if (Mathf.Abs(moveInput.x) <= 0 && _agent2D.AgentRigidbody2D.velocity == Vector2.zero)
            {
                //change state
                return;
            }

            _agent2D.AgentRigidbody2D.velocity = new Vector2(moveInput.x * this.agent2DMovementData.MovementSpeed, _agent2D.AgentRigidbody2D.velocity.y);
        }
    }
}