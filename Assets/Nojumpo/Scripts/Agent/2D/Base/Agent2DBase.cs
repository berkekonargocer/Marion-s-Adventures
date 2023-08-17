using UnityEngine;

namespace Nojumpo
{
    public abstract class Agent2DBase : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public AgentAnimator agentAnimator { get; set; }

        public Rigidbody2D AgentRigidbody2D { get; protected set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
        }

        protected virtual void FixedUpdate() {
            HandleMovement();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        protected virtual void SetComponents() {
            this.AgentRigidbody2D = GetComponent<Rigidbody2D>();
        }

        public virtual void HandleMovement() {

            // else
            // {
                if (Mathf.Abs(this.AgentRigidbody2D.velocity.x) > 0)
                {
                    this.agentAnimator.PlayAnimation("Idle");
                }
            // }
            
            // if (moveInput.x == 0)
            //     return;
            //
            // AgentRigidbody2D.velocity = new Vector2(moveInput.x * movementSpeed, AgentRigidbody2D.velocity.y);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Agent2DStateBase newState, PlayerIdleState idleState) {
            
        }
    }
}
