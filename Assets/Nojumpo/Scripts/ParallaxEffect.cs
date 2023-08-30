using UnityEngine;

namespace Nojumpo
{
    public class ParallaxEffect : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Transform _cameraTransform;
        Vector3 _lastCameraPosition;

        float _textureUnitSizeX;
        float _textureUnitSizeY;
        
        [SerializeField] Vector2 parallaxEffectMultiplier;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void LateUpdate() {
            ApplyParallax();
            RepeatXPosition();
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _cameraTransform = Camera.main.transform;
            _lastCameraPosition = _cameraTransform.position;
            
            Sprite objectSprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D objectTexture2D = objectSprite.texture;
            _textureUnitSizeX = objectTexture2D.width / objectSprite.pixelsPerUnit;
            _textureUnitSizeY = objectTexture2D.height / objectSprite.pixelsPerUnit;
        }

        void ApplyParallax() {
            Vector3 cameraPosition = _cameraTransform.position;
            Vector3 deltaMovement = cameraPosition - _lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
            _lastCameraPosition = cameraPosition;
        }
        
        void RepeatXPosition() {
            if (Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _textureUnitSizeX)
            {
                Vector3 cameraPosition = _cameraTransform.position;
                float offsetPositionX = (cameraPosition.x - transform.position.x) % _textureUnitSizeX; 
                transform.position = new Vector3(cameraPosition.x - offsetPositionX, transform.position.y);
            }
        }

        /// <summary>
        /// Use this with a bool (optional) if you need a infinite background in y position
        /// </summary>
        void RepeatYPosition() {
            if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _textureUnitSizeY)
            {
                Vector3 cameraPosition = _cameraTransform.position;
                float offsetPositionY = (cameraPosition.y - transform.position.y) % _textureUnitSizeY;  
                transform.position = new Vector3(transform.position.x, cameraPosition.y - offsetPositionY);
            }
        }
    }
}