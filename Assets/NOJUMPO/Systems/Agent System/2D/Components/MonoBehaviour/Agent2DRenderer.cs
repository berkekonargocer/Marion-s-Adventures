using Nojumpo.ScriptableObjects;
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


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _agent2DTransform = GetComponent<Transform>();
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void FaceDirection(Vector2 movementVector) {
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