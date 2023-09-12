using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
{
    [RequireComponent(typeof(Collider2D))]
    public class Agent2DGroundDetector : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask groundLayerMask;
        [Range(-2f, 2f)] [SerializeField] float boxCastYOffset = -0.4f;
        [Range(-2f, 2f)] [SerializeField] float boxCastXOffset;
        [Range(0f, 2f)] [SerializeField] float boxCastWidth = 1.0f, boxCastHeight = 0.5f;

        [SerializeField] Color groundedColor = Color.green, notGroundedGizmoColor = Color.red;

        Collider2D _agent2DCollider;

        RaycastHit2D[] _groundedHits = new RaycastHit2D[1];

        public bool IsGrounded { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnDrawGizmos() {
            if (_agent2DCollider == null)
                return;

            Gizmos.color = notGroundedGizmoColor;

            if (IsGrounded)
                Gizmos.color = groundedColor;

            Gizmos.DrawWireCube(_agent2DCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector3(boxCastWidth, boxCastHeight));
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agent2DCollider = GetComponent<Collider2D>();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void CheckIsGrounded() {
            int groundedHits = Physics2D.BoxCastNonAlloc(_agent2DCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector2(boxCastWidth, boxCastHeight), 0, Vector2.down, _groundedHits, 0, groundLayerMask);

            if (groundedHits == 1)
            {
                if (_groundedHits[0].collider.IsTouching(_agent2DCollider))
                    IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }
        }
    }
}