using Nojumpo.Enums;
using Nojumpo.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo
{
    public class HealthBar : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Health HealthToDisplay { get; private set; }
        [field: SerializeField] public Image HealthBarForeground { get; private set; }
        [field: SerializeField] public Image HealthBarBackground { get; private set; }
        [field: SerializeField] public Image HealthBarChangeIndicator { get; private set; }
        [Space]
        [SerializeField] HealthChangeAnimationType healthChangeAnimationType;
        [SerializeField] [Range(0.001f, 0.1f)] float animationSpeed = 0.0075f;
        [SerializeField] [Range(0.5f, 2.0f)] float animationWaitTime = 1.0f;

        IHealthChangeAnimation _healthChangeAnimation;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {
            HealthToDisplay.onTakeDamage += HealthBar_OnTakeDamage;
            HealthToDisplay.onHeal += HealthBar_OnHeal;
        }

        void OnDisable() {
            HealthToDisplay.onTakeDamage -= HealthBar_OnTakeDamage;
            HealthToDisplay.onHeal -= HealthBar_OnHeal;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            switch (healthChangeAnimationType)
            {
                case HealthChangeAnimationType.CHIP_AWAY:
                    _healthChangeAnimation = new HealthChangeAnimation_ChipAway(animationSpeed, animationWaitTime);
                    break;
                case HealthChangeAnimationType.DEFAULT:
                    _healthChangeAnimation = new HealthChangeAnimation_Default();
                    break;
            }
        }

        void HealthBar_OnTakeDamage() {
            _healthChangeAnimation.OnTakeDamageAnimation(this);
        }

        void HealthBar_OnHeal() {
            _healthChangeAnimation.OnHealAnimation(this);
        }
    }
}