using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.CollectableSystem
{
    public abstract class Collectable2D : MonoBehaviour, ICollectable
    {
        // -------------------------------- FIELDS ---------------------------------
        public UnityEvent OnCollected;
        [SerializeField] AudioClip collectSFX;
        [SerializeField] AudioSource sfxAudioSource;
        [SerializeField] GameObject collectVFXPrefab;
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void OnEnable() {
            if (sfxAudioSource == null)
            {
                sfxAudioSource = GameObject.FindWithTag("SFX Audio Source").GetComponent<AudioSource>();
            }
        }

        public virtual void Collect(GameObject collector) {
            OnCollected?.Invoke();

            if (collectVFXPrefab != null)
            {
                GameObject vfx = Instantiate(collectVFXPrefab, transform.position, Quaternion.identity);
                Destroy(vfx, 1.25f);
            }
            
            if (sfxAudioSource != null && collectSFX != null)
            {
                sfxAudioSource.PlayOneShot(collectSFX);
            }
        }

    }
}