using Nojumpo.Enums;
using Nojumpo.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
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

        [SerializeField] HealthChangeAnimationType healthChangeAnimationType;
        [SerializeField] [Range(0.1f, 1.0f)] float animationSpeed = 0.5f;
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

        void Start() {

        }

        void Update() {

        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            switch (healthChangeAnimationType)
            {
                case HealthChangeAnimationType.CHIP_AWAY:
                    _healthChangeAnimation = new HealthChangeAnimation_ChipAway(animationSpeed, animationWaitTime);
                    break;
            }
        }

        void HealthBar_OnTakeDamage() {
            _healthChangeAnimation.OnTakeDamageAnimation(this);
        }

        void HealthBar_OnHeal() {
            _healthChangeAnimation.OnHealAnimation(this);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
