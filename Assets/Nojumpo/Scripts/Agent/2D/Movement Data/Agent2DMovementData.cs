using System;
using Nojumpo.Interfaces;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DMovementData : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [field: SerializeField] public float MovementSpeed { get; set; }
        
        [SerializeField] MovementControlType movementControlType;
        public IMovementControlType iMovementControlType { get; private set; }

        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void Awake() {
            SetMovementControlType(this.movementControlType);
        }

        void SetMovementControlType(MovementControlType movementControl) {
            switch (movementControl)
            {
                case MovementControlType.INPUT:
                    this.iMovementControlType = new MovementControlType_Input();
                    break;
                case MovementControlType.CLICK:
                    break;
            }
        } 
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        
    }
}