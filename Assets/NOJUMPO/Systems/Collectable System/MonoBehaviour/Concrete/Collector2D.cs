using UnityEngine;

namespace NOJUMPO.CollectableSystem
{
    public class Collector2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask collectableLayerMask;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & collectableLayerMask) != 0)
            {
                other.GetComponent<ICollectable>().Collect(gameObject);
            }
        }
    }
}