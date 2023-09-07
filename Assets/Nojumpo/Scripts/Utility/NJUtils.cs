using System.Collections.Generic;
using UnityEngine;

namespace Nojumpo.Utils
{
    public static class NJUtils
    {
        public static Camera MainCam { get; } = Camera.main;
        
        static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
        /// <summary>
        /// Better WaitForSeconds. 
        /// Looks if there are same valued WaitForSeconds if you have uses it to not create garbage
        /// if not, creates it
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static WaitForSeconds GetWait(float time) {
            if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

            WaitDictionary[time] = new WaitForSeconds(time);
            return WaitDictionary[time];
        }

        /// <summary>
        /// Put any object to the canvas, spawn particles on canvas etc.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <returns></returns>
        public static Vector2 GetWorldPositionOfCanvasElement(RectTransform rectTransform) {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, rectTransform.position, MainCam, out var result);
            return result;
        }

        /// <summary>
        /// Set the visibility and lock state of cursor
        /// </summary>
        /// <param name="isVisible"></param>
        public static void SetCursorState(bool isVisible) {
            Cursor.visible = isVisible;
            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
