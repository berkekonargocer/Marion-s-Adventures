namespace Nojumpo.DamageableSystem
{
    public interface IHealthChangeAnimation
    {
        // -------------------------------- FIELDS ---------------------------------
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar);
        public void OnHealAnimation(HealthBar healthBar);
    }
}