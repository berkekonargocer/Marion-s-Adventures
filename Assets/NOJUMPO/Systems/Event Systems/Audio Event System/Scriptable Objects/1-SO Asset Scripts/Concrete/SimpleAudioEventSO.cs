using System;
using Nojumpo.EditorAttributes;
using Nojumpo.Variables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nojumpo.AudioEventSystem
{
    [CreateAssetMenu(fileName = "NewSimpleAudioEvent", menuName = "Nojumpo/Scriptable Objects/Audio Event/New Simple Audio Event")]
    public class SimpleAudioEventSO : AudioEventBaseSO
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] AudioClip[] _audioClips;

        [SerializeField] RangedFloat _volume;
        [MinMaxRange(0f, 2f)] [SerializeField] RangedFloat _audioPitch;


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void Play() {
            _audioEventSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            _audioEventSource.volume = Random.Range(_volume.MinValue, _volume.MaxValue);
            _audioEventSource.pitch = Random.Range(_audioPitch.MinValue, _audioPitch.MaxValue);
            _audioEventSource.Play();
        }

        public override void Play(SimpleAudioEventSO simpleAudioEventSo) {
            if (_audioClips.Length == 0) { return; }

            simpleAudioEventSo._audioEventSource.clip = simpleAudioEventSo._audioClips[Random.Range(0, simpleAudioEventSo._audioClips.Length)];
            simpleAudioEventSo._audioEventSource.volume = Random.Range(simpleAudioEventSo._volume.MinValue, simpleAudioEventSo._volume.MaxValue);
            simpleAudioEventSo._audioEventSource.pitch = Random.Range(simpleAudioEventSo._audioPitch.MinValue, simpleAudioEventSo._audioPitch.MaxValue);
            simpleAudioEventSo._audioEventSource.Play();
        }

        public override void Play(AudioSource audioSource) {
            if (_audioClips.Length == 0) { return; }

            audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            audioSource.volume = Random.Range(_volume.MinValue, _volume.MaxValue);
            audioSource.pitch = Random.Range(_audioPitch.MinValue, _audioPitch.MaxValue);
            audioSource.Play();
        }

        public override void PlayOneShot(AudioSource audioSource) {
            throw new NotImplementedException();
        }

        public override void Stop(AudioSource audioSource) {
            throw new NotImplementedException();
        }
    }
}