using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public class Point : Collectable2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] int amount;

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CollectAnimation() {
            // Play animation and destroy it 
            Destroy(gameObject);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Collect(GameObject collector) {
            collector.gameObject.GetComponent<PointManager>().AddPoint(amount);
            CollectAnimation();
        }
    }
}