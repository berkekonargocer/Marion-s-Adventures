using UnityEngine;

namespace Nojumpo.AudioEventSystem
{
    public abstract class AudioEventBaseSO : ScriptableObject
    {
    #if UNITY_EDITOR
        [Multiline] [SerializeField] string _developerDescription;

    #endif

        public virtual void Play(AudioSource audioSource) { }
        public virtual void PlayOneShot(AudioSource audioSource) { }
        public abstract void Stop(AudioSource audioSource);
    }
}