using UnityEngine;

namespace Nojumpo.PointCollectionSystem
{
    public abstract class PointCollectorBase : MonoBehaviour, IPointCollector
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected LayerMask pointLayerMask;

        public int CurrentPoint { get { return _currentPoint; } }

        int _currentPoint;

        public delegate void OnPointCollected();
        public OnPointCollected onPointCollected;
        
        
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