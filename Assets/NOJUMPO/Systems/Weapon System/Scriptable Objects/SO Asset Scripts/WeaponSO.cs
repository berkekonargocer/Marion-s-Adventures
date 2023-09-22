using System;
using Nojumpo.AgentSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponSO", menuName = "Nojumpo/Scriptable Objects/Weapon System/New Weapon")]
    public abstract class WeaponSO : ScriptableObject, IEquatable<WeaponSO>
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public WeaponData WeaponData { get; private set; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool Equals(WeaponSO weapon) {
            if (weapon != null)
            {
                return WeaponData.WeaponName == weapon.WeaponData.WeaponName;
            }

            Debug.Log("Weapon Equals Check Parameter Is Null! Returning False");
            return false;
        }

        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agent2DBase agent2D, LayerMask hittableLayerMask, Vector3 direction);
        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction) {
        }
    }
}