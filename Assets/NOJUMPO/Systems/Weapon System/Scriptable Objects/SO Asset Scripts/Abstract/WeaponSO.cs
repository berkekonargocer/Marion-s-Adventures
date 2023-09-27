using System;
using Nojumpo.AgentSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    public abstract class WeaponSO : ScriptableObject, IEquatable<WeaponSO>
    {
#if UNITY_EDITOR
        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public WeaponData WeaponData { get; private set; }
        [SerializeField] protected LayerMask damageableLayerMask;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool Equals(WeaponSO weapon) {
            if (weapon != null)
            {
                return WeaponData.Name == weapon.WeaponData.Name;
            }

            Debug.Log("Weapon Equals Check Parameter Is Null! Returning False");
            return false;
        }

        public abstract bool CanBeUsed(bool isGrounded);
        public virtual void PerformAttack(Agent2D agent2D, Vector3 attackDirection) {
            WeaponData.AttackAudioEvent.Play();
        }
        public abstract void TryToDealDamage(Agent2D agent2D, Vector3 attackDirection);
        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction) {
        }
    }
}