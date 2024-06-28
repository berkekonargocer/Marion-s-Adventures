using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace NOJUMPO.CollectableSystem
{
    public class PointsPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public PointManager PointsToDisplay { get; private set; }
        [SerializeField] TextMeshProUGUI pointsText;
        [SerializeField] string pointsTag = "Point";
        
        public UnityEvent OnPanelUpdate;

        int _pointAmountInTheCurrentLevel;
                
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            PointsToDisplay.OnPointChange.AddListener(UpdatePointsPanel);
            SceneManager.sceneLoaded += GetPointAmountInTheLevel;
        }

        void Start() {
            UpdatePointsPanel();
        }

        void OnDisable() {
            PointsToDisplay.OnPointChange.RemoveListener(UpdatePointsPanel);
            SceneManager.sceneLoaded -= GetPointAmountInTheLevel;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void GetPointAmountInTheLevel(Scene scene,LoadSceneMode loadSceneMode) {
            GameObject[] pointsAmount = GameObject.FindGameObjectsWithTag(pointsTag);
            _pointAmountInTheCurrentLevel = pointsAmount.Length;
        }
        
        void UpdatePointsPanel() {
            pointsText.text = $"{PointsToDisplay.CurrentPoint.ToString()} / {_pointAmountInTheCurrentLevel.ToString()}";
            OnPanelUpdate?.Invoke();
        }

    }
}