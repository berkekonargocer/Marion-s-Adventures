using System;
using DG.Tweening;
using Nojumpo.Interfaces;

namespace Nojumpo
{
    [Serializable]
    public class HealthChangeAnimation_Default : IHealthChangeAnimation
    {
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 0.25f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 1.00f);
        }

        public void OnHealAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.HealthToDisplay.HealthDecimal, 0.45f);
        }

    }
}
