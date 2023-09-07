using UnityEngine;

namespace Nojumpo
{
    [RequireComponent(typeof(Collider2D))]
    public class DestroyObjectsOnTrigger2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask destroyableLayerMasks;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            Collider2D objectCollider2D = gameObject.GetComponent<Collider2D>();

            if (objectCollider2D.isTrigger == false)
            {
                objectCollider2D.isTrigger = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & destroyableLayerMasks) != 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}