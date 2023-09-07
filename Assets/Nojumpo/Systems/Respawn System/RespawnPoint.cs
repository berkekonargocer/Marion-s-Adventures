using UnityEngine;

namespace Nojumpo
{
    public class RespawnPoint : MonoBehaviour
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetRespawnPoint(out Vector3 respawnPoint) {
            respawnPoint = transform.position;
        }
    }
}