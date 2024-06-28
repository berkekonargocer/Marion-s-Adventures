using UnityEngine;

namespace NOJUMPO.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Nojumpo/Scriptable Objects/Data/Variables/New Float Variable")]
    public class FloatVariableSO : ScriptableObject
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [Tooltip("Float value to use")]
        [SerializeField] float value;
        public float Value { get { return value; } set { this.value = value; } }


        // ------------------------ CUSTOM PUBLIC METHODS ------------------------
        public void SetValue(float valueToSet) {
            Value = valueToSet;
        }

        public void SetValue(FloatVariableSO floatVariable) {
            Value = floatVariable.Value;
        }

        public void ApplyChange(float changeAmount) {
            Value += changeAmount;
        }

        public void ApplyChange(FloatVariableSO changeAmount) {
            Value += changeAmount.Value;
        }
    }
}
