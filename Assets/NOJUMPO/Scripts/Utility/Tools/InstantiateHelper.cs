using UnityEngine;

namespace Nojumpo
{
    public class InstantiateHelper : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InstantiateObject(GameObject objectToInstantiate) {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    }
}