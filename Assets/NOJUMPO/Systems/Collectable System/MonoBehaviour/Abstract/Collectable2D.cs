using System;
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
        void OnEnable() {
            if (sfxAudioSource == null)
            {
                sfxAudioSource = GameObject.FindWithTag("SFX Audio Source").GetComponent<AudioSource>();
            }
        }

        public virtual void Collect(GameObject collector) {
            OnCollected?.Invoke();

            if (sfxAudioSource != null && collectSFX != null)
            {
                sfxAudioSource.PlayOneShot(collectSFX);
            }
        }

    }
}