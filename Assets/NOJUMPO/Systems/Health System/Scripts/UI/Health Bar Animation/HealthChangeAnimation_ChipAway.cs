using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Nojumpo.HealthSystem
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
            healthBar.HealthBarForeground.fillAmount = healthBar.healthToDisplay.HealthDecimal;

            if (_isAnimationInProgress)
                return;

            TakeDamageAnimation(healthBar);
        }

        public void OnHealAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 0.45f);
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
