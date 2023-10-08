using TMPro;
using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class PointsPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public PointManager PointsToDisplay { get; private set; }
        [SerializeField] TextMeshProUGUI pointsText;


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
        }

    }
}