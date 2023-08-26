using System;
using Unity.VisualScripting;
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

        bool _isGrounded;


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

            if (_isGrounded)
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

    }
}
