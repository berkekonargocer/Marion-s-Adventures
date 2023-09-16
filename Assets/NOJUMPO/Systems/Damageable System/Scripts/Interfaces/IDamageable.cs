namespace Nojumpo.DamageableSystem
{
    public interface IDamageable
    {
        // -------------------------------- FIELDS ---------------------------------
        public Health DamageableHealth { get; }
        public DamageResistances Resistances { get; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount, DamageTypeSO damageType);
        public void Heal(float healAmount);
    }
}