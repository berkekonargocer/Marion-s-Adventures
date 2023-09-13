using UnityEngine;

namespace Nojumpo
{
    public class PointCollector3D : PointCollectorBase
    {
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & pointLayerMask) != 0)
            {
                other.GetComponent<Point>().Collect(this);
            }
        }
    }
}