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


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void DealDamage() {
            AgentDamageable.TakeDamage(damageAmount, damageType);
        }

        void Heal() {
            AgentDamageable.Heal(healAmount);
        }
    }
}