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
            DamageableObject.onTakeDamage += Damageable_OnTakeDamage;
            DamageableObject.onHeal += Damageable_OnHeal;
        }

        void OnDisable() {
            DamageableObject.onTakeDamage -= Damageable_OnTakeDamage;
            DamageableObject.onHeal -= Damageable_OnHeal;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _healthBarAnimator = GetComponent<HealthBarAnimator>();
        }

        void Damageable_OnTakeDamage() {
            _healthBarAnimator.TakeDamageAnimation(this);
        }

        void Damageable_OnHeal() {
            _healthBarAnimator.HealAnimation(this);
        }
    }
}