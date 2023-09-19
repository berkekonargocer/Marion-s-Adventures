using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo
{
    public class Respawnable : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask respawnPointLayerMask;
        [SerializeField] LayerMask respawnTriggerLayerMask;
        [SerializeField] RespawnPoint initialRespawnPoint;
        [SerializeField] int respawnDamage = 25;

        Vector3 _currentRespawnPoint;

        DamageTypeSO _respawnDamageType;

        public delegate void OnRespawn(float respawnDamage, DamageTypeSO respawnDamageType);
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
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _currentRespawnPoint = initialRespawnPoint.transform.position;
        }

        void Respawn() {
            transform.position = _currentRespawnPoint;
            onRespawn?.Invoke(respawnDamage, _respawnDamageType);
        }
    }
}