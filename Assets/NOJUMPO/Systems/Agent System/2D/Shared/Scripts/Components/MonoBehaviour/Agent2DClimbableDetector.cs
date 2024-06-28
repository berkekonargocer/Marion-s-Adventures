using UnityEngine;

namespace NOJUMPO
{
    public class Agent2DClimbableDetector : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask climbableLayerMask;

        public bool CanClimb { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & climbableLayerMask) != 0)
            {
                CanClimb = true;
            }
        }

        void OnTriggerExit2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & climbableLayerMask) != 0)
            {
                CanClimb = false;
            }
        }
    }
}