using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Nojumpo
{
    public class FPSCounter : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        float fps;
        GUIStyle style = new GUIStyle();


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            style.fontSize = 24;
            StartCoroutine(nameof(UpdateFPS));
        }

        void OnGUI() {
            GUI.Label(new Rect(10, 10, 200, 50), "FPS: " + Mathf.Round(fps), style);
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator UpdateFPS() {
            while (true)
            {
                fps = 1.0f / Time.deltaTime;
                yield return new WaitForSeconds(1);
            }
        }
    }
}