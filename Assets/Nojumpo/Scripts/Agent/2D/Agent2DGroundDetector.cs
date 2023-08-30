using UnityEngine;

namespace Nojumpo
{
    public class Agent2DGroundDetector : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [Header("BOXCAST PARAMETERS")]
        [SerializeField] Collider2D agent2dCollider;
        [SerializeField] LayerMask groundLayerMask;
        [Range(-2f, 2f)] [SerializeField] float boxCastYOffset = -0.4f;
        [Range(-2f, 2f)] [SerializeField] float boxCastXOffset;
        [Range(0f, 2f)] [SerializeField] float boxCastWidth = 1.0f, boxCastHeight = 0.5f;

        [SerializeField] Color groundedColor = Color.green, notGroundedGizmoColor = Color.red;

        RaycastHit2D[] _groundedHits = new RaycastHit2D[1];

        public bool IsGrounded { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {

        }

        void OnDisable() {

        }

        void Start() {

        }

        void Update() {

        }

        void OnDrawGizmos() {
            if (agent2dCollider == null)
                return;

            Gizmos.color = notGroundedGizmoColor;

            if (IsGrounded)
                Gizmos.color = groundedColor;

            Gizmos.DrawWireCube(agent2dCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector3(boxCastWidth, boxCastHeight));
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            if (agent2dCollider == null)
            {
                agent2dCollider = GetComponent<Collider2D>();
            }
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void CheckIsGrounded() {
            int groundedHits = Physics2D.BoxCastNonAlloc(agent2dCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector2(boxCastWidth, boxCastHeight), 0, Vector2.down, _groundedHits, 0, groundLayerMask);

            if (groundedHits == 1)
            {
                if (_groundedHits[0].collider.IsTouching(agent2dCollider))
                    IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }
        }
    }
}
