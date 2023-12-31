using UnityEngine;

namespace Nojumpo
{
    public class Agent2DRenderer : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Transform _agent2DTransform;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void FaceDirection(Vector2 movementVector) {
            if (movementVector.x > 0)
            {
                _agent2DTransform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (movementVector.x < 0)
            {
                _agent2DTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
        public void FaceDirection(int movementDirection) {
            if (movementDirection > 0)
            {
                _agent2DTransform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (movementDirection < 0)
            {
                _agent2DTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agent2DTransform = GetComponent<Transform>();
        }
    }
}