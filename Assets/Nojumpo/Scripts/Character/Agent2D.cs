using UnityEngine;

namespace Nojumpo
{
    public abstract class Agent2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected float movementSpeed;
        [field: SerializeField] public AgentAnimator agentAnimator { get; set; }

        protected Rigidbody2D _rigidbody2D;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
        }

        protected virtual void FixedUpdate() {
            HandleMovement();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        protected virtual void SetComponents() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected virtual void HandleMovement() {

            // else
            // {
                if (Mathf.Abs(_rigidbody2D.velocity.x) > 0)
                {
                    this.agentAnimator.PlayAnimation("Idle");
                }
            // }
            
            // if (moveInput.x == 0)
            //     return;
            //
            // _rigidbody2D.velocity = new Vector2(moveInput.x * movementSpeed, _rigidbody2D.velocity.y);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Agent2DState newState, PlayerIdleState idleState) {
            
        }
    }
}
