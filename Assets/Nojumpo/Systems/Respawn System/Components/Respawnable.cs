using NOJUMPO.DamageableSystem;
using UnityEngine;

namespace NOJUMPO
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

        void OnDisable() {
            if (TryGetComponent(out IDamageable damageable))
            {
                onRespawn -= damageable.TakeDamage;
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            if (initialRespawnPoint == null)
            {
                Debug.LogWarning("Initial Respawn Point Is Not Set You Need To Set An Initial Respawn Point", gameObject);
                return;
            }
            
            _currentRespawnPoint = initialRespawnPoint.transform.position;
            
            if (TryGetComponent(out IDamageable damageable))
            {
                onRespawn += damageable.TakeDamage;
            }
        }

        void Respawn() {
            transform.position = _currentRespawnPoint;
            onRespawn?.Invoke(respawnDamage, _respawnDamageType);
        }
    }
}