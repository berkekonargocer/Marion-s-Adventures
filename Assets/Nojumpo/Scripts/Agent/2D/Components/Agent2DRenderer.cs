using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DRenderer : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] InputReader inputReader;
        
        Transform _agent2DTransform;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {
            inputReader.onMovementInputPressed += FaceDirection;
        }

        void OnDisable() {
            inputReader.onMovementInputPressed -= FaceDirection;
        }
        

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agent2DTransform = GetComponent<Transform>();
        }

        void FaceDirection(Vector2 movementVector) {
            if (movementVector.x > 0)
            {
                _agent2DTransform.localScale = Vector3.one;
            }

            if (movementVector.x < 0)
            {
                _agent2DTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
