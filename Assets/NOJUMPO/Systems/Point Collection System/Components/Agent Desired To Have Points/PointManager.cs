using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.CollectableSystem
{
    public class PointManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public int CurrentPoint { get { return _currentPoint; } }
        int _currentPoint;

        public UnityEvent OnPointChange;
        

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddPoint(int addAmount) {
            _currentPoint += addAmount;
            OnPointChange?.Invoke();
        }
    }
}