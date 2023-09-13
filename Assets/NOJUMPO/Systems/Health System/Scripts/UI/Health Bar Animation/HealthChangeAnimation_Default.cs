using System;
using DG.Tweening;

namespace Nojumpo.HealthSystem
{
    [Serializable]
    public class HealthChangeAnimation_Default : IHealthChangeAnimation
    {
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 0.25f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 1.00f);
        }

        public void OnHealAnimation(HealthBar healthBar) {
            healthBar.HealthBarForeground.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(healthBar.healthToDisplay.HealthDecimal, 0.45f);
        }

    }
}
