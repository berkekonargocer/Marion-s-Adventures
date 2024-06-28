using NOJUMPO.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO.UI
{
    public class SliderSetterFloat : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [Tooltip("Slider to set")]
        [SerializeField] Slider _slider;

        [Tooltip("Float Variable Scriptable Object Value to equalize to the Slider value")]
        [SerializeField] FloatVariableSO _variable;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            if (_slider == null)
            {
                Debug.Log($"Slider '{_slider}' is not set! disabling the component", gameObject);
                enabled = false;
                return;
            }

            if (_variable == null)
            {
                Debug.Log($"Variable '{_variable}' is not set! disabling the component", gameObject);
                enabled = false;
            }
        }

        void Update() {
            if ((int)_slider.value == (int)_variable.Value)
                return;

            _slider.value = _variable.Value;
        }
    }
}