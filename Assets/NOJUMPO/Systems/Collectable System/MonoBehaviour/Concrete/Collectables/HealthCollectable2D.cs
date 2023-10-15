using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class HealthCollectable2D : Collectable2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float healAmount;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        protected override void OnEnable() {
            collectVFXPrefabPath = "VFX/Particle System/Prefabs/Health Collect VFX";
            base.OnEnable();
        }

        public override void Collect(GameObject collector) {
            base.Collect(collector);
            collector.gameObject.GetComponent<Damageable>().Heal(healAmount);
            Destroy(gameObject);
        }

    }
}