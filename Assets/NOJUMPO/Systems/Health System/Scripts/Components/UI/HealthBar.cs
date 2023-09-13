using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo.HealthSystem
{
    [RequireComponent(typeof(HealthBarAnimator))]
    public class HealthBar : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Health healthToDisplay { get; private set; }
        [field: SerializeField] public Image HealthBarForeground { get; private set; }
        [field: SerializeField] public Image HealthBarBackground { get; private set; }
        [field: SerializeField] public Image HealthBarChangeIndicator { get; private set; }

        HealthBarAnimator _healthBarAnimator;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {
            healthToDisplay.onTakeDamage += Health_OnTakeDamage;
            healthToDisplay.onHeal += Health_OnHeal;
        }

        void OnDisable() {
            healthToDisplay.onTakeDamage -= Health_OnTakeDamage;
            healthToDisplay.onHeal -= Health_OnHeal;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _healthBarAnimator = GetComponent<HealthBarAnimator>();
        }

        void Health_OnTakeDamage() {
            _healthBarAnimator.TakeDamageAnimation(this);
        }

        void Health_OnHeal() {
            _healthBarAnimator.HealAnimation(this);
        }
    }
}