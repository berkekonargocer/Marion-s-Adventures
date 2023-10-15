using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.CollectableSystem
{
    public enum CollectVFXSpawnPosition
    {
        COLLECTOR,
        COLLECTABLE
    }
    
    public abstract class Collectable2D : MonoBehaviour, ICollectable
    {
        // -------------------------------- FIELDS ---------------------------------
        public UnityEvent OnCollected;
        [SerializeField] AudioClip collectSFX;
        [SerializeField] AudioSource sfxAudioSource;
        [SerializeField] protected GameObject collectVFXPrefab;
        [SerializeField] protected string collectVFXPrefabPath = "";
        [SerializeField] protected CollectVFXSpawnPosition vfxSpawnPosition;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void OnEnable() {
            SetComponents();
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void Collect(GameObject collector) {
            OnCollected?.Invoke();
            
            SpawnVFX(collector);
            PlaySFX();
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            if (collectVFXPrefab == null)
            {
                collectVFXPrefab = Resources.Load<GameObject>(collectVFXPrefabPath);
            }

            if (sfxAudioSource == null)
            {
                sfxAudioSource = GameObject.FindWithTag("SFX Audio Source").GetComponent<AudioSource>();
            }
        }
        
        void PlaySFX() {
            if (sfxAudioSource != null && collectSFX != null)
            {
                sfxAudioSource.PlayOneShot(collectSFX);
            }
        }
        
        void SpawnVFX(GameObject collector) {
            if (collectVFXPrefab == null)
                return;
            
            GameObject vfx = Instantiate(collectVFXPrefab, VFXSpawnPosition(collector), Quaternion.identity);
            Destroy(vfx, 1.25f);
        }

        Vector3 VFXSpawnPosition(GameObject collector) {
            Vector3 spawnPosition = vfxSpawnPosition switch
            {
                CollectVFXSpawnPosition.COLLECTOR => collector.transform.position,
                CollectVFXSpawnPosition.COLLECTABLE => transform.position,
                _ => Vector3.zero
            };

            return spawnPosition;
        }
    }
}