using System;
using Nojumpo.HealthSystem;
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
            AgentHealth.TakeDamage(damageAmount, damageType);
        }

        void Heal() {
            AgentHealth.Heal(healAmount);
        }
    }
}