using UnityEngine;

namespace Nojumpo
{
    public class DestroyObjectsOnTrigger2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask destroyableLayerMasks;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & destroyableLayerMasks) != 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}