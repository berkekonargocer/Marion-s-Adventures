using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo
{
    public class Marion : Agent2DBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float damageAmount;
        [SerializeField] float healAmount;
        [SerializeField] DamageTypeSO damageType;
        Damageable _agentDamageable;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();
            _agentDamageable = GetComponent<Damageable>();
        }
        void OnEnable() {
            GameInputReader.onAttackInputPressed += DealDamage;
            GameInputReader.onHealInputPressed += Heal;
        }

        void OnDisable() {
            GameInputReader.onAttackInputPressed -= DealDamage;
            GameInputReader.onHealInputPressed -= Heal;
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void DealDamage() {
            _agentDamageable.TakeDamage(damageAmount, damageType);
        }

        void Heal() {
            _agentDamageable.Heal(healAmount);
        }
    }
}