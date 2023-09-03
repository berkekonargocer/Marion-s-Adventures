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


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect() {
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

            _pointCollectorToAddThePointsTo.onPointCollected?.Invoke();
        }
    }
}