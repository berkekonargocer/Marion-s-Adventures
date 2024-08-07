using NOJUMPO.DamageableSystem;
using UnityEngine;

namespace NOJUMPO.CollectableSystem
{
    public class HealthCollectable2D : Collectable2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float healAmount;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        protected override void OnEnable() {
            collectVFXPrefabPath = "VFX/Particle System/Prefabs/Health Collect VFX";
            vfxSpawnPosition = CollectVFXSpawnPosition.COLLECTOR;
            base.OnEnable();
        }

        public override void Collect(GameObject collector) {
            base.Collect(collector);
            collector.gameObject.GetComponent<Damageable>().Heal(healAmount);
            Destroy(gameObject);
        }

    }
}