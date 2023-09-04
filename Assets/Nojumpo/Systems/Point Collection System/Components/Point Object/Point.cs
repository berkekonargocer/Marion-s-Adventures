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
        [SerializeField] PointsPanel pointsPanel;
        [SerializeField] PointType pointType;
        [SerializeField] int amount;

        PointCollector _pointCollectorToAddThePointsTo;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _pointCollectorToAddThePointsTo = pointsPanel.PointsToDisplay;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void PointTypeResponse() {
            switch (pointType)
            {
                case PointType.ADD:
                    _pointCollectorToAddThePointsTo.AddPoint(amount);
                    break;
                case PointType.SUBTRACT:
                    _pointCollectorToAddThePointsTo.SubtractPoint(amount);
                    break;
                case PointType.MULTIPLY:
                    _pointCollectorToAddThePointsTo.MultiplyPoint(amount);
                    break;
            }
        }

        void CollectAnimation() {
            // Play animation and destroy it 
            Destroy(gameObject);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect() {
            PointTypeResponse();

            _pointCollectorToAddThePointsTo.onPointCollected?.Invoke();

            CollectAnimation();
        }
    }
}