using UnityEngine;

namespace NOJUMPO.CollectableSystem
{
    public interface ICollectable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect(GameObject collector);
    }
}