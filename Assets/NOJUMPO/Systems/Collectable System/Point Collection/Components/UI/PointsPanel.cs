using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Nojumpo.CollectableSystem
{
    public class PointsPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public PointManager PointsToDisplay { get; private set; }
        [SerializeField] TextMeshProUGUI pointsText;

        public UnityEvent OnPanelUpdate;

        int _pointAmountInTheCurrentLevel;
                
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            PointsToDisplay.OnPointChange.AddListener(UpdatePointsPanel);
            SceneManager.sceneLoaded += UpdatePointAmountInTheLevel;
        }

        void Start() {
            UpdatePointsPanel();
        }

        void OnDisable() {
            PointsToDisplay.OnPointChange.RemoveListener(UpdatePointsPanel);
            SceneManager.sceneLoaded -= UpdatePointAmountInTheLevel;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void UpdatePointAmountInTheLevel(Scene scene,LoadSceneMode loadSceneMode) {
            GameObject[] pointsAmount = GameObject.FindGameObjectsWithTag("Point");
            _pointAmountInTheCurrentLevel = pointsAmount.Length;
            Debug.Log($"{pointsAmount.Length.ToString()}");
        }
        
        void UpdatePointsPanel() {
            pointsText.text = $"{PointsToDisplay.CurrentPoint.ToString()} / {_pointAmountInTheCurrentLevel.ToString()}";
            OnPanelUpdate?.Invoke();
        }

    }
}