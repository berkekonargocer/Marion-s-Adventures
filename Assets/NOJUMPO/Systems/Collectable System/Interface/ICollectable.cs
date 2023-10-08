using UnityEngine;

namespace Nojumpo.CollectableSystem
{
    public interface ICollectable
    {
        // -------------------------------- FIELDS ---------------------------------
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
	    public void Collect(GameObject collector); 
    }
}