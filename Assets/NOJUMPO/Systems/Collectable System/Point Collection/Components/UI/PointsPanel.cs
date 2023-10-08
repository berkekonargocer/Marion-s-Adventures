using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.CollectableSystem
{
    public class PointsPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public PointManager PointsToDisplay { get; private set; }
        [SerializeField] TextMeshProUGUI pointsText;

        public UnityEvent OnPanelUpdate;

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            UpdatePointsPanel();
            PointsToDisplay.OnPointChange.AddListener(UpdatePointsPanel);
        }

        void OnDisable() {
            PointsToDisplay.OnPointChange.RemoveListener(UpdatePointsPanel);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void UpdatePointsPanel() {
            pointsText.text = $"{PointsToDisplay.CurrentPoint.ToString()}";
            OnPanelUpdate?.Invoke();
        }

    }
}