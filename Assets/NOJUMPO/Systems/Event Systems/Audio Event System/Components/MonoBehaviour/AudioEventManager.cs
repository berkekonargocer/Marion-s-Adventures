using UnityEngine;

namespace Nojumpo.AudioEventSystem
{
    public class AudioEventManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioEventBaseSO[] audioEvents;
        [SerializeField] AudioSource audioEventSource;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            for (int i = audioEvents.Length - 1; i >= 0; i--)
            {
                audioEvents[i].SetAudioSource(audioEventSource);
            }
        }
    }
}