using System;
using UnityEngine;

namespace Nojumpo.ScriptableObjects.References
{
    [Serializable]
    public class FloatReference
    {
        // -------------------------------- FIELDS ---------------------------------
        [Tooltip("On = Use the Constant Value value that set in this script \n" +
            "Off = Use a Float Variable Scriptable Object value")]
        [SerializeField] bool useConstant = true;

        [Tooltip("Constant Value to use ")]
        [SerializeField] float constantValue;

        [Tooltip("Float Variable Scriptable Object Value to read from")]
        [SerializeField] FloatVariableSO variable;

        public float Value { get { return useConstant ? constantValue : variable.Value; } }
    }
}