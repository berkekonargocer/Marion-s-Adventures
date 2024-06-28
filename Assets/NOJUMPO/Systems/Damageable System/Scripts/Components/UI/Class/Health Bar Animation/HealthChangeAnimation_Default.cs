using System;
using DG.Tweening;

namespace NOJUMPO.DamageableSystem
{
    [Serializable]
    public class HealthChangeAnimation_Default : IHealthChangeAnimation
    {
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void OnTakeDamageAnimation(HealthBar healthBar) {
            float endValue = healthBar.DamageableObject.DamageableHealth.HealthDecimal;
            healthBar.HealthBarForeground.DOFillAmount(endValue, 0.25f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(endValue, 1.00f);
        }

        public void OnHealAnimation(HealthBar healthBar) {
            float endValue = healthBar.DamageableObject.DamageableHealth.HealthDecimal;
            healthBar.HealthBarForeground.DOFillAmount(endValue, 0.45f);
            healthBar.HealthBarChangeIndicator.DOFillAmount(endValue, 0.45f);
        }
    }
}