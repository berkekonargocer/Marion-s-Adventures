using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public interface ICollectable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Collect(GameObject collector);
    }
}