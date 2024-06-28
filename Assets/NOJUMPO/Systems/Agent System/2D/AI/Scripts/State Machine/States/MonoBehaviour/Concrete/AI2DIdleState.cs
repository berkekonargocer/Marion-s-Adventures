using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public class AI2DIdleState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] PhysicsMaterial2D normalFrictionMaterial2D;
        [SerializeField] PhysicsMaterial2D noFrictionMaterial2D;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}