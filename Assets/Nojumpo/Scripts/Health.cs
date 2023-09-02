using Nojumpo.Interfaces;

namespace Nojumpo
{
    public class Health : IDamageable
    {
        // -------------------------------- FIELDS --------------------------------
        public delegate void OnTakeDamage();
        public OnTakeDamage onTakeDamage;

        public delegate void OnHeal();
        public OnHeal onHeal;

        public delegate void OnDie();
        public OnDie onDie;

        public float CurrentHealth { get { return _currentHealth; } }
        public float MaxHealth { get { return _maxHealth; } }
        public float HealthPercentage { get { return CurrentHealth / MaxHealth; } }

        float _currentHealth;
        readonly float _maxHealth;


        // ----------------------------- CONSTRUCTORS -----------------------------
        public Health(float maxHealth) {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount) {
            _currentHealth -= damageAmount;
            onTakeDamage?.Invoke();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                onDie?.Invoke();
            }
        }

        public void Heal(float healAmount) {
            _currentHealth += healAmount;
            onHeal?.Invoke();
            
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }
    }
}
