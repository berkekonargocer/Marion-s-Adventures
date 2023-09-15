namespace Nojumpo.DamageableSystem
{
    public interface IHealable
    {
        // -------------------------------- FIELDS ---------------------------------
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public float HealthPercentage { get; }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void IncreaseHealth(float healAmount);
    }
}