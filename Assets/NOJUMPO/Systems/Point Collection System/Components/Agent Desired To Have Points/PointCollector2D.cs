using UnityEngine;

namespace Nojumpo.PointCollectionSystem
{
    public class PointCollector2D : PointCollector
    {
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & pointLayerMask) != 0)
            {
                other.GetComponent<Point>().Collect(this);
            }
        }
    }
}