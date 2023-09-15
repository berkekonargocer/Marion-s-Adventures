using UnityEngine;

namespace Nojumpo.HealthSystem
{
    public class Health : MonoBehaviour, IDamageable, IHealable
    {
        // -------------------------------- FIELDS --------------------------------
        public delegate void OnTakeDamage();
        public OnTakeDamage onTakeDamage;

        public delegate void OnHeal();
        public OnHeal onHeal;

        public delegate void OnDie();
        public OnDie onDie;

        public float MaxHealth { get { return maxHealth; } }
        public float CurrentHealth { get { return _currentHealth; } }
        public float HealthPercentage { get { return CurrentHealth / MaxHealth * 100; } }
        public float HealthDecimal { get { return CurrentHealth / MaxHealth; } }

        [SerializeField] [Min(1)] float maxHealth = 100.0f;
        float _currentHealth;

        [SerializeField] DamageTypeSO[] vulnerableDamageTypes;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _currentHealth = maxHealth;
        }

        float CalculateDamage(float damageAmount, DamageTypeSO damageType) {
            for (int i = vulnerableDamageTypes.Length - 1; i >= 0; i--)
            {
                if (damageType == vulnerableDamageTypes[i])
                {
                    damageAmount *= 2;
                }
            }

            return damageAmount;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount, DamageTypeSO damageType) {
            _currentHealth -= CalculateDamage(damageAmount, damageType);
            onTakeDamage?.Invoke();

            if (!(_currentHealth <= 0))
                return;

            _currentHealth = 0;
            onDie?.Invoke();
        }

        public void Heal(float healAmount) {
            _currentHealth += healAmount;
            onHeal?.Invoke();

            _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        }
    }
}