using System;
using UnityEngine;

namespace Nojumpo
{
    public class SpawnPointChecker : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask spawnPointLayerMask;
        [SerializeField] LayerMask spawnTriggerLayerMask;
        [SerializeField] SpawnPoint initialSpawnPoint;

        Vector3 _currentSpawnPoint;

        public delegate void OnSpawn();
        public OnSpawn onSpawn;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _currentSpawnPoint = initialSpawnPoint.transform.position;
        }

        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & spawnPointLayerMask) != 0)
            {
                other.GetComponent<SpawnPoint>().SetSpawnPoint(out _currentSpawnPoint);
            }
            else if ((collisionLayerMask & spawnTriggerLayerMask) != 0)
            {
                Respawn();
                onSpawn?.Invoke();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void Respawn() {
            transform.position = _currentSpawnPoint;
        }
    }
}