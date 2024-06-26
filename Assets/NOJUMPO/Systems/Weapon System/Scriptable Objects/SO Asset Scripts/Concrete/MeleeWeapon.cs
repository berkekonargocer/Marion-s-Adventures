using Nojumpo.AgentSystem;
using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [CreateAssetMenu(fileName = "NewMeleeWeapon", menuName = "Nojumpo/Scriptable Objects/Weapon System/Melee/New Melee Weapon")]
    public class MeleeWeapon : WeaponSO
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public float m_AttackRange { get; private set; } = 1.5f;

        RaycastHit2D[] weaponHitResult = new RaycastHit2D[5];


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override bool CanBeUsed(bool isGrounded) {
            return isGrounded;
        }

        public override void PerformAttack(Agent2D agent2D, Vector3 attackDirection, AudioSource attackSFXSource) {
            PlayAttackSFX(attackSFXSource);
            TryToDealDamage(agent2D, attackDirection, attackSFXSource);
        }

        public override void TryToDealDamage(Agent2D agent2D, Vector3 attackDirection, AudioSource audioSource) {
            int hits = Physics2D.RaycastNonAlloc(agent2D.m_AgentWeapon.transform.position, attackDirection, weaponHitResult, m_AttackRange, damageableLayerMask);

            if (hits <= 0)
                return;

            PlayAttackHitSFX(audioSource);
            
            for (int i = 0; i < hits; i++)
            {
                IDamageable damageable = weaponHitResult[i].collider.GetComponent<IDamageable>();
                int damage = Random.Range(WeaponData.MinDamage, WeaponData.MaxDamage + 1);
                damageable.TakeDamage(damage, WeaponData.DamageType, agent2D.gameObject, WeaponData.DoesKnockback, WeaponData.KnockbackForce);
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction) {
            Gizmos.DrawLine(origin, origin + (direction * m_AttackRange));
        }
    }
}