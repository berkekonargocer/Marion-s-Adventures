using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    public class HealthBarAnimator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] HealthChangeAnimationType healthChangeAnimationType;
        [SerializeField] [Range(0.001f, 0.1f)] float animationSpeed = 0.0075f;
        [SerializeField] [Range(0.5f, 2.0f)] float animationWaitTime = 1.0f;

        IHealthChangeAnimation _healthChangeAnimation;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
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
        

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void TakeDamageAnimation(HealthBar healthBar) {
            _healthChangeAnimation.OnTakeDamageAnimation(healthBar);
        }
        
        public void HealAnimation(HealthBar healthBar) {
            _healthChangeAnimation.OnHealAnimation(healthBar);
        }
    }
}