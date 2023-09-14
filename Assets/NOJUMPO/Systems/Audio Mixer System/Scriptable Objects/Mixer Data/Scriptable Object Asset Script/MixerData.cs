using Nojumpo.ScriptableObjects;
using UnityEngine;
using UnityEngine.Audio;

namespace Nojumpo.AudioMixerSystem
{
    [CreateAssetMenu(fileName = "NewMixerData", menuName = "Nojumpo/Scriptable Objects/Audio/New Mixer Data")]
    public class MixerData : ScriptableObject
    {
        
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [Tooltip("Mixer to control its mixer groups")]
        [SerializeField] AudioMixer mixer;

        [Tooltip("Mixer group (EXPOSED PARAMETER NAME SHOULD BE EXACTLY SAME AS MIXER GROUP NAME)")]
        [SerializeField] AudioMixerGroup mixerGroup;

        [Tooltip("Volume of the mixer group ")]
        [SerializeField] FloatVariableSO mixerVolume;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeMixerValue() {
            float currentMixerVolume = mixerVolume.Value > 0.0f ? 20.0f * Mathf.Log10(mixerVolume.Value) : -80.0f;
            mixer.SetFloat(mixerGroup.name, currentMixerVolume);
        }
    }
}
