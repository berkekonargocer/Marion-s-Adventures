using Nojumpo.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
{
    public class PointCollector : MonoBehaviour, IPointCollector
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask pointLayerMask;

        public int CurrentPoint { get { return _currentPoint; } }

        int _currentPoint;

        public delegate void OnPointCollected();
        public OnPointCollected onPointCollected;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & pointLayerMask) != 0)
            {
                other.GetComponent<Point>().Collect(this);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddPoint(int addAmount) {
            _currentPoint += addAmount;
        }

        public void SubtractPoint(int subtractAmount) {
            _currentPoint -= subtractAmount;
        }

        public void MultiplyPoint(int multiplyAmount) {
            _currentPoint *= multiplyAmount;
        }
    }
}