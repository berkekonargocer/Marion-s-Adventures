using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    public interface IDamageable
    {
        // -------------------------------- FIELDS ---------------------------------
        public Health DamageableHealth { get; }
        public DamageResistances Resistances { get; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount, DamageTypeSO damageType);
        public void TakeDamage(float damageAmount, DamageTypeSO damageType, GameObject damageDealer, bool knockbackOnGetHit, float knockbackForce);
        public void Heal(float healAmount);
    }
}