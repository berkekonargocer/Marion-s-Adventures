using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo.DamageableSystem
{
    [RequireComponent(typeof(HealthBarAnimator))]
    public class HealthBar : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Damageable DamageableObject { get; private set; }
        [field: SerializeField] public Image HealthBarForeground { get; private set; }
        [field: SerializeField] public Image HealthBarBackground { get; private set; }
        [field: SerializeField] public Image HealthBarChangeIndicator { get; private set; }

        HealthBarAnimator _healthBarAnimator;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {
            DamageableObject.onTakeDamage += OnTakeDamage;
            DamageableObject.onHeal += OnHeal;
        }

        void OnDisable() {
            DamageableObject.onTakeDamage -= OnTakeDamage;
            DamageableObject.onHeal -= OnHeal;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _healthBarAnimator = GetComponent<HealthBarAnimator>();
        }

        void OnTakeDamage() {
            _healthBarAnimator.TakeDamageAnimation(this);
        }

        void OnHeal() {
            _healthBarAnimator.HealAnimation(this);
        }
    }
}