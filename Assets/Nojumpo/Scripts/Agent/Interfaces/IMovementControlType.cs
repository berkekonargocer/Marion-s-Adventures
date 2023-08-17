using UnityEngine;

namespace Nojumpo.Interfaces
{
    public enum MovementControlType
    {
        INPUT,
        CLICK
    }
    
    public interface IMovementControlType
    {
        // -------------------------------- FIELDS ---------------------------------
        
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Move(Rigidbody2D rigidbody2D, float movementSpeed);
        public void Move(Rigidbody rigidbody, float movementSpeed);
        public Vector2 MovementInput();
    }
}