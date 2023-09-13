using Nojumpo.Interfaces;
using UnityEngine;

namespace Nojumpo
{
    public enum PointType
    {
        ADD,
        SUBTRACT,
        MULTIPLY
    }

    public class Point : MonoBehaviour, IPoint
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] PointType pointType;
        [SerializeField] int amount;

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void PointTypeResponse(PointCollectorBase pointCollector) {
            switch (pointType)
            {
                case PointType.ADD:
                    pointCollector.AddPoint(amount);
                    break;
                case PointType.SUBTRACT:
                    pointCollector.SubtractPoint(amount);
                    break;
                case PointType.MULTIPLY:
                    pointCollector.MultiplyPoint(amount);
                    break;
            }
        }

        void CollectAnimation() {
            // Play animation and destroy it 
            Destroy(gameObject);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect(PointCollectorBase pointCollector) {
            PointTypeResponse(pointCollector);

            pointCollector.onPointCollected?.Invoke();

            CollectAnimation();
        }
    }
}