using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class HealthCollectable2D : Collectable2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float healAmount;

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Collect(GameObject collector) {
            collector.gameObject.GetComponent<Damageable>().Heal(healAmount);
            Destroy(gameObject);
        }

    }
}