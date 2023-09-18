using UnityEngine;

namespace Nojumpo.AudioEventSystem
{
    public abstract class AudioEventBaseSO : ScriptableObject
    {
    #if UNITY_EDITOR

        [Multiline]
        [SerializeField] string _developerDescription;

    #endif

        public abstract void Play(AudioSource source);
        public abstract void PlayOneShot(AudioSource source);
        public abstract void Stop(AudioSource source);
    }
}