using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class HealthCollectable2D : MonoBehaviour, ICollectable
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float healAmount;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect(GameObject collector) {
            collector.gameObject.GetComponent<Damageable>().Heal(healAmount);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}