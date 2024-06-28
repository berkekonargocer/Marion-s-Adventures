using UnityEngine;

namespace NOJUMPO
{
    public class RespawnPoint : MonoBehaviour
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetRespawnPoint(out Vector3 respawnPoint) {
            respawnPoint = transform.position;
        }
    }
}