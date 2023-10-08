using DG.Tweening;
using UnityEngine;

namespace Nojumpo.Utils
{
    public class HoverAnimation2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float movementDistance = 0.4f;
        [SerializeField] float animationDuration = 1.0f;
        [SerializeField] Ease animationEase;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            transform.DOMoveY(transform.position.y + movementDistance, animationDuration)
                .SetEase(animationEase)
                .SetLoops(-1, LoopType.Yoyo);
        }

        void OnDisable() {
            DOTween.Kill(transform);
        }
    }
}