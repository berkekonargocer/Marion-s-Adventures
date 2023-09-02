using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo
{
    public class HealthBar : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Health healthToDisplay;
        [SerializeField] Image healthBarForeground;
        [SerializeField] Image healthBarBackground;
        [SerializeField] Image healthBarChangeIndicator;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {

        }

        void OnEnable() {
            healthToDisplay.onTakeDamage += HealthBar_OnTakeDamage;
            healthToDisplay.onHeal += HealthBar_OnHeal;
        }

        void OnDisable() {
            healthToDisplay.onTakeDamage -= HealthBar_OnTakeDamage;
            healthToDisplay.onHeal -= HealthBar_OnHeal;
        }

        void Start() {

        }

        void Update() {

        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void HealthBar_OnTakeDamage() {
            healthBarForeground.fillAmount = healthToDisplay.HealthDecimal;
            
        }
        
        void HealthBar_OnHeal() {
            
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
