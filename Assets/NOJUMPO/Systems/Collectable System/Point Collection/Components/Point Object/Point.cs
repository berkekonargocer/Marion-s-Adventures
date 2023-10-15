using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class Point : Collectable2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] int amount;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Collect(GameObject collector) {
            base.Collect(collector);
            collector.gameObject.GetComponent<PointManager>().AddPoint(amount);
            CollectAnimation();
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CollectAnimation() {
            // Play animation and destroy it 
            Destroy(gameObject);
        }
    }
}