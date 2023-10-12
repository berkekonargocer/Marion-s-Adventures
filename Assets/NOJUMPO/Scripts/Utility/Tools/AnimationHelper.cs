using DG.Tweening;
using UnityEngine;

namespace Nojumpo.Utils
{
    public class AnimationHelper : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float animationDuration = 0.5f;
        [SerializeField] Ease animationEase;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ScaleAnimation(RectTransform rectTransform) {
            float initialScale = rectTransform.localScale.x;
            rectTransform.DOScale(1.2f, animationDuration).SetEase(animationEase).onComplete
                = () =>
                    rectTransform.DOScale(initialScale, animationDuration).SetEase(animationEase);
        }
    }
}