using Nojumpo.Variables;
using Nojumpo.EditorAttributes;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nojumpo.AudioEventSystem
{
    [CreateAssetMenu(fileName = "NewSimpleAudioEvent", menuName = "Nojumpo/Scriptable Objects/Audio Event/New Simple Audio Event")]
    public class SimpleAudioEventSO : AudioEventBaseSO
    {
        [SerializeField] AudioClip[] _audioClips;

        [SerializeField] RangedFloat _volume;

        [MinMaxRange(0f, 2f)]
        [SerializeField] RangedFloat _audioPitch;


        public override void Play(AudioSource source) {
            if (_audioClips.Length == 0) { return; }

            source.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            source.volume = Random.Range(_volume.MinValue, _volume.MaxValue);
            source.pitch = Random.Range(_audioPitch.MinValue, _audioPitch.MaxValue);
            source.Play();
        }

        public override void PlayOneShot(AudioSource source) {
            throw new NotImplementedException();
        }

        public override void Stop(AudioSource source) {
            throw new NotImplementedException();
        }
    }
}