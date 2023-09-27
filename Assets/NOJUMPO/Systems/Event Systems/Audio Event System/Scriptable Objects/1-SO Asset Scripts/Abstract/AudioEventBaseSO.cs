using UnityEngine;

namespace Nojumpo.AudioEventSystem
{
    public abstract class AudioEventBaseSO : ScriptableObject
    {
    #if UNITY_EDITOR
        [Multiline] [SerializeField] string _developerDescription;

    #endif

        // -------------------------------- FIELDS ---------------------------------
        protected AudioSource _audioEventSource;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void SetAudioSource(AudioSource audioSource) {
            _audioEventSource = audioSource;
        }

        public abstract void Play();
        public virtual void Play(SimpleAudioEventSO simpleAudioEventSo) { }
        public virtual void Play(AudioSource audioSource) { }
        public virtual void PlayOneShot(AudioSource audioSource) { }
        public abstract void Stop(AudioSource audioSource);
    }
}