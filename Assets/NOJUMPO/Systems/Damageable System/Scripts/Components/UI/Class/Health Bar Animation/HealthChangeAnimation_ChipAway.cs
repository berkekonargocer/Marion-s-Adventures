using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    [Serializable]
    public class HealthChangeAnimation_ChipAway : IHealthChangeAnimation
    {
        // -------------------------------- FIELDS --------------------------------
        float _animationSpeed;
        float _animationWaitTime;
        bool _isAnimationInProgress;

        // ----------------------------- CONSTRUCTORS -----------------------------
        public HealthChangeAnimation_ChipAway(float animationSpeed, float animationWaitTime) {
            _animationSpeed = animationSpeed;
            _animationWaitTime = animationWaitTime;
        }
        

        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.fillAmount = healthBar.DamageableObject.DamageableHealth.HealthDecimal;

            if (_isAnimationInProgress)
                return;

            TakeDamageAnimation(healthBar);
        }

        public void OnHealAnimation(HealthBar healthBar) {
            float endValue = healthBar.DamageableObject.DamageableHealth.HealthDecimal;
            healthBar.HealthBarForeground.DOFillAmount(endValue, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(endValue, 0.45f);
        }

        async void TakeDamageAnimation(HealthBar healthBar) {
            _isAnimationInProgress = true;

            await Task.Delay((int)_animationWaitTime * 1000);

            while (healthBar.HealthBarForeground.fillAmount < healthBar.HealthBarChangeIndicator.fillAmount)
            {
                healthBar.HealthBarChangeIndicator.fillAmount = Mathf.MoveTowards(healthBar.HealthBarChangeIndicator.fillAmount, healthBar.HealthBarForeground.fillAmount, _animationSpeed);
                await Task.Yield();
            }
            
            _isAnimationInProgress = false;
        }
    }
}
