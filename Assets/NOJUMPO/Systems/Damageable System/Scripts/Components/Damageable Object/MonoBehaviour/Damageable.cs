using NOJUMPO.AudioEventSystem;
using NOJUMPO.ScriptableObjects;
using System;
using UnityEngine;

namespace NOJUMPO.DamageableSystem
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] FloatVariableSO maxHealth;
        [field: SerializeField] public DamageResistances Resistances { get; private set; }

        [SerializeField] AudioEventBaseSO TakeDamageAudioEvent;
        [SerializeField] AudioSource TakeDamageAudioSource;

        public Health DamageableHealth { get; private set; }
        public bool IsDead { get { return DamageableHealth.CurrentHealth < 0; } }

        Rigidbody2D _damageableObjectRigidbody;

        public event Action OnTakeDamage;
        public event Action OnHeal;
        public event Action OnDie;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamage(float damageAmount, DamageTypeSO damageType, GameObject damageDealer, bool knockbackOnGetHit, float knockbackForce) {
            DamageableHealth.DecreaseHealth(Resistances.CalculateDamageWithResistances(damageAmount, damageType));
            TakeDamageAudioEvent.Play(TakeDamageAudioSource);
            OnTakeDamage?.Invoke();

            if (knockbackOnGetHit && DamageableHealth.CurrentHealth > 0)
            {
                GetKnockedback(damageDealer, knockbackForce);
            }

            if (!(DamageableHealth.CurrentHealth <= 0))
                return;

            DamageableHealth.SetHealth(0);
            OnDie?.Invoke();
        }

        public void TakeDamage(float damageAmount, DamageTypeSO damageType) {
            DamageableHealth.DecreaseHealth(Resistances.CalculateDamageWithResistances(damageAmount, damageType));
            TakeDamageAudioEvent.Play(TakeDamageAudioSource);
            OnTakeDamage?.Invoke();

            if (!(DamageableHealth.CurrentHealth <= 0))
                return;

            DamageableHealth.SetHealth(0);
            OnDie?.Invoke();
        }

        public void Heal(float healAmount) {
            DamageableHealth.IncreaseHealth(healAmount);
            OnHeal?.Invoke();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            DamageableHealth = new Health(maxHealth.Value);
            _damageableObjectRigidbody = GetComponent<Rigidbody2D>();
        }

        void GetKnockedback(GameObject damageDealer, float knockbackForce) {
            Vector2 direction = transform.position - damageDealer.transform.position;
            _damageableObjectRigidbody.AddForce(new Vector2(direction.normalized.x, 0) * knockbackForce, ForceMode2D.Impulse);
        }
    }
}