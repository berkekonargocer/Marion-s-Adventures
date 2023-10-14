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
        
        

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void Collect(GameObject collector) {
            OnCollected?.Invoke();

            if (sfxAudioSource != null && collectSFX != null)
            {
                sfxAudioSource.PlayOneShot(collectSFX);
            }
        }

    }
}