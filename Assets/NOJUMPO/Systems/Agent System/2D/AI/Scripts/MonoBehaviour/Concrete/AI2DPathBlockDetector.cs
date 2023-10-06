using System.Collections;
using Nojumpo.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo
{
    public class AI2DPathBlockDetector : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform detectionPosition;
        [SerializeField] LayerMask groundLayerMask;
        [SerializeField] float edgeCheckLength = 0.1f;
        [SerializeField] float wallCheckLength = 0.5f;
        [SerializeField] [Range(0, 1)] float edgeRaycastDelay = 0.1f;

        public bool IsPathBlocked { get; private set; }

        RaycastHit2D[] forwardCheckHits = new RaycastHit2D[1];
        RaycastHit2D[] downCheckHits = new RaycastHit2D[1];

        [SerializeField] Color raycastColor = Color.blue;
        [SerializeField] bool showGizmos = true;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            StartCoroutine(nameof(CheckForGroundCoroutine));
        }

        void OnDrawGizmos() {
            Gizmos.color = raycastColor;
            Vector3 raycastPosition = detectionPosition.position;
            Gizmos.DrawRay(raycastPosition, Vector2.down * edgeCheckLength);
            Gizmos.DrawRay(raycastPosition, transform.right * wallCheckLength);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator CheckForGroundCoroutine() {
            while (true)
            {
                Vector3 raycastPosition = detectionPosition.position;
                int downHits = Physics2D.RaycastNonAlloc(raycastPosition, Vector2.down, downCheckHits, edgeCheckLength, groundLayerMask);
                int forwardHits = Physics2D.RaycastNonAlloc(raycastPosition, transform.right, forwardCheckHits, wallCheckLength, groundLayerMask);

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