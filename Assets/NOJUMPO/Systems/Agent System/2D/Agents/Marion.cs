using Nojumpo.DamageableSystem;
using Nojumpo.WeaponSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Marion : Agent2DBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float damageAmount;
        [SerializeField] float healAmount;
        [SerializeField] DamageTypeSO damageType;
        Damageable _agentDamageable;

        public WeaponManager MarionWeaponManager { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameInputReader.onAttackInputPressed += DealDamage;
            GameInputReader.onHealInputPressed += Heal;
        }

        void OnDisable() {
            GameInputReader.onAttackInputPressed -= DealDamage;
            GameInputReader.onHealInputPressed -= Heal;
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        protected override void SetComponents() {
            base.SetComponents();
            _agentDamageable = GetComponent<Damageable>();
            MarionWeaponManager = GetComponent<WeaponManager>();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void DealDamage() {
            _agentDamageable.TakeDamage(damageAmount, damageType);
        }

        void Heal() {
            _agentDamageable.Heal(healAmount);
        }
    }
}