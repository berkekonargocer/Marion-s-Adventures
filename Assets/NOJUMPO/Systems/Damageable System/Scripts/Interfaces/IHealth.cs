namespace NOJUMPO.DamageableSystem
{
    public interface IHealth
    {
        // -------------------------------- FIELDS ---------------------------------
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public float HealthPercentage { get; }

    }
}