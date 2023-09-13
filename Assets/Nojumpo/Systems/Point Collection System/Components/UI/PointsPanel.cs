using TMPro;
using UnityEngine;

namespace Nojumpo.PointCollectionSystem
{
    public class PointsPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public PointCollectorBase PointsToDisplay { get; private set; }
        [SerializeField] TextMeshProUGUI pointsText;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            UpdatePointsPanel();
            PointsToDisplay.onPointCollected += UpdatePointsPanel;
        }

        void OnDisable() {
            PointsToDisplay.onPointCollected -= UpdatePointsPanel;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void UpdatePointsPanel() {
            pointsText.text = $"{PointsToDisplay.CurrentPoint.ToString()}";
        }

    }
}