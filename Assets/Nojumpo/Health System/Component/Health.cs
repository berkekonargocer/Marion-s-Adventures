using System;
using Nojumpo.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
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

        [SerializeField] [Range(1.0f, 1000.0f)] float maxHealth;
        float _currentHealth;

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        
        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _currentHealth = maxHealth;
        }
        
        // a attack that deals 100 damage
        // armor component that lessens the damage 30 armor lessens the %10 damage
        

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

            _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        }
    }
}