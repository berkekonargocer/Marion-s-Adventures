using System.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class AI2DPathBlockDetector : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform detectionPosition;
        [SerializeField] LayerMask blockLayerMask;
        [SerializeField] float groundCheckLength = 0.1f;
        [SerializeField] float wallCheckLength = 0.5f;

        public bool IsPathBlocked { get; private set; }

        RaycastHit2D[] forwardCheckHits = new RaycastHit2D[1];
        RaycastHit2D[] downCheckHits = new RaycastHit2D[1];

        [Space]
        [Header("GIZMOS")]
        [SerializeField] bool showGizmos = true;
        [SerializeField] Color raycastColor = Color.blue;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            StartCoroutine(nameof(CheckForGroundCoroutine));
        }

        void OnDrawGizmos() {
            Gizmos.color = raycastColor;
            Vector3 raycastPosition = detectionPosition.position;
            Gizmos.DrawRay(raycastPosition, Vector2.down * groundCheckLength);
            Gizmos.DrawRay(raycastPosition, transform.right * wallCheckLength);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator CheckForGroundCoroutine() {
            while (true)
            {
                Vector3 raycastPosition = detectionPosition.position;
                int downHits = Physics2D.RaycastNonAlloc(raycastPosition, Vector2.down, downCheckHits, groundCheckLength, blockLayerMask);
                int forwardHits = Physics2D.RaycastNonAlloc(raycastPosition, transform.right, forwardCheckHits, wallCheckLength, blockLayerMask);

                if (downHits > 0 && forwardHits <= 0)
                {
                    IsPathBlocked = false;
                }
                else
                {
                    IsPathBlocked = true;
                }
                
                yield return null;
            }
        }
    }
}