using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponSO", menuName = "Nojumpo/Scriptable Objects/Weapon System/New Weapon")]
    public class WeaponSO : ScriptableObject
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public WeaponData WeaponData { get; private set; }
        [field: SerializeField] public Sprite WeaponSprite { get; private set; }
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
    }
}