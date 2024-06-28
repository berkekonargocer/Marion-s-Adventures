using System;
using UnityEngine;

namespace NOJUMPO.DamageableSystem
{
    [Serializable]
    public class Health : IHealth, IHealable
    {
        // -------------------------------- FIELDS --------------------------------
        public float MaxHealth {
            get {
                return _maxHealth;
            }
            private set {
                _maxHealth = value < 1 ? 1 : value;
            }
        }
        
        public float CurrentHealth {
            get {
                return _currentHealth;
            }
            private set {
                _currentHealth = value >= _maxHealth ? _maxHealth : value;
            }
        }

        public float HealthPercentage { get { return CurrentHealth / MaxHealth * 100; } }
        public float HealthDecimal { get { return CurrentHealth / MaxHealth; } }

        float _maxHealth;
        float _currentHealth;


        // ---------------------------- CONSTRUCTORS ------------------------------
        public Health(float maxHealth) {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void SetHealth(float value) {
            CurrentHealth = value;
        }

        public void DecreaseHealth(float decreaseAmount) {
            CurrentHealth -= decreaseAmount;
        }

        public void IncreaseHealth(float healAmount) {
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        }
    }
}