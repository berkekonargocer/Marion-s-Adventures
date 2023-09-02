namespace Nojumpo.Interfaces
{
    public interface IDamageable
    {
        // -------------------------------- FIELDS ---------------------------------
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public float HealthPercentage { get; }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount);
        public void Heal(float healAmount);
    }
}
