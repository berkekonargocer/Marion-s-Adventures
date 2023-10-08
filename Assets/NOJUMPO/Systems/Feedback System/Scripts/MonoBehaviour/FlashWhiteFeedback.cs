using System.Collections;
using Nojumpo.Utils;
using UnityEngine;

namespace Nojumpo.FeedbackSystem
{
    public class FlashWhiteFeedback : MonoBehaviour, IFeedback
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] float feedbackTime = 0.1f;
        
        static readonly int _makeSolidColor = Shader.PropertyToID("_MakeSolidColor");


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ApplyFeedback() {
            if (spriteRenderer == null || !spriteRenderer.material.HasProperty("_MakeSolidColor"))
                return;
            
            ToggleMaterial(1);
            StopAllCoroutines();
            StartCoroutine(nameof(ResetColor));
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ToggleMaterial(int toggle) {
            toggle = Mathf.Clamp(toggle, 0, 1);
            
            spriteRenderer.material.SetInt(_makeSolidColor, toggle);
        }
        
        IEnumerator ResetColor() {
            yield return NJUtils.GetWait(feedbackTime);
            ToggleMaterial(0);
        }
    }
}