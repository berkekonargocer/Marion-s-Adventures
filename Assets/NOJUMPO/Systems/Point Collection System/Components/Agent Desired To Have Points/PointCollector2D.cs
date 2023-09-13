using UnityEngine;

namespace Nojumpo
{
    public class PointCollector2D : PointCollectorBase
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