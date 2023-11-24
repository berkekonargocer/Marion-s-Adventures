using DG.Tweening;
using UnityEngine;

namespace Nojumpo.Utils
{
    public class AnimationHelper : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float endScaleValue = 0.8f;
        [SerializeField] float animationDuration = 0.5f;
        [SerializeField] Ease animationEase;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ScaleAnimation(RectTransform rectTransform) {
            float initialScale = rectTransform.localScale.x;
            rectTransform.DOScale(endScaleValue, animationDuration).SetEase(animationEase).onComplete
                = () =>
                    rectTransform.DOScale(initialScale, animationDuration).SetEase(animationEase);
        }
    }
}