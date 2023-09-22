using Nojumpo.AgentSystem;
using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [CreateAssetMenu(fileName = "NewMeleeWeapon", menuName = "Nojumpo/Scriptable Objects/Weapon System/Melee/New Melee Weapon")]
    public class MeleeWeapon : WeaponSO
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public float AttackRange { get; private set; } = 2.5f;

        RaycastHit2D[] weaponHitResult = new RaycastHit2D[5];


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override bool CanBeUsed(bool isGrounded) {
            return isGrounded;
        }

        public override void PerformAttack(Agent2DBase agent2D, LayerMask hittableLayerMask, Vector3 direction) {
            int hits = Physics2D.RaycastNonAlloc(agent2D.AgentWeaponManager.transform.position, direction, weaponHitResult, AttackRange, hittableLayerMask);

            for (int i = 0; i < hits; i++)
            {
                Damageable damageable = weaponHitResult[i].collider.GetComponent<Damageable>();
                damageable.TakeDamage(WeaponData.Damage, WeaponData.DamageType);
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction) {
            Gizmos.DrawLine(origin, origin + direction * AttackRange);
        }
    }
}