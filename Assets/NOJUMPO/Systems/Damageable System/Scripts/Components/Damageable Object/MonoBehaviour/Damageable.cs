using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        // -------------------------------- FIELDS ---------------------------------
        public delegate void OnTakeDamage();
        public OnTakeDamage onTakeDamage;

        public delegate void OnHeal();
        public OnHeal onHeal;

        public delegate void OnDie();
        public OnDie onDie;
        public Health DamageableHealth { get; private set; }

        [SerializeField] float maxHealth;
        [field: SerializeField] public DamageResistances Resistances { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            DamageableHealth = new Health(maxHealth);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------



        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount, DamageTypeSO damageType) {
            DamageableHealth.DecreaseHealth(Resistances.CalculateDamageWithResistances(damageAmount, damageType));
            onTakeDamage?.Invoke();

            if (!(DamageableHealth.CurrentHealth <= 0))
                return;

            DamageableHealth.SetHealth(0);
            onDie?.Invoke();
        }

        public void Heal(float healAmount) {
            DamageableHealth.IncreaseHealth(healAmount);
            onHeal?.Invoke();
        }
    }
}