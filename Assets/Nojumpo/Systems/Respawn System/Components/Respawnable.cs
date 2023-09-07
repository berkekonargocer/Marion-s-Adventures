using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
{
    public class Respawnable : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask respawnPointLayerMask;
        [SerializeField] LayerMask respawnTriggerLayerMask;
        [SerializeField] RespawnPoint initialRespawnPoint;

        Vector3 _currentRespawnPoint;

        public delegate void OnRespawn();
        public OnRespawn onRespawn;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnTriggerEnter2D(Collider2D other) {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer;

            if ((collisionLayerMask & respawnPointLayerMask) != 0)
            {
                other.GetComponent<RespawnPoint>().SetRespawnPoint(out _currentRespawnPoint);
            }
            else if ((collisionLayerMask & respawnTriggerLayerMask) != 0)
            {
                Respawn();
                onRespawn?.Invoke();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _currentRespawnPoint = initialRespawnPoint.transform.position;
        }

        void Respawn() {
            transform.position = _currentRespawnPoint;
        }
    }
}