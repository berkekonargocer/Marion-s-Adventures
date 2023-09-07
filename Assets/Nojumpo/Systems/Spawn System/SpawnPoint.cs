using UnityEngine;

namespace Nojumpo
{
    public class SpawnPoint : MonoBehaviour
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetSpawnPoint(out Vector3 spawnPoint) {
            spawnPoint = transform.position;
        }
    }
}