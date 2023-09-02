using System;
using DG.Tweening;
using Nojumpo.Interfaces;
using UnityEngine.UI;

namespace Nojumpo
{
    [Serializable]
    public class HealthChangeAnimation_ChipAway : IHealthChangeAnimation
    {
        // -------------------------------- FIELDS --------------------------------
        float _animationSpeed;
        float _animationTimer;
        float _animationWaitTime;


        // ----------------------------- CONSTRUCTORS -----------------------------
        public HealthChangeAnimation_ChipAway(float animationSpeed, float animationWaitTime) {
            _animationSpeed = animationSpeed;
            _animationWaitTime = animationWaitTime;
        }

        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.fillAmount = healthBar.HealthToDisplay.HealthDecimal;
        }
        
        public void OnHealAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 0.45f);
        }
    }
}
