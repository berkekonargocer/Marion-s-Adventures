using Nojumpo.ScriptableObjects;
using Nojumpo.Interfaces;
using UnityEngine;

namespace Nojumpo
{
    public class MovementControlType_Input : IMovementControlType
    {
        // -------------------------------- FIELDS --------------------------------


        // ----------------------------- CONSTRUCTORS -----------------------------


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void Move(Rigidbody2D rigidbody2D, float movementSpeed) {
            Vector2 moveInput = InputReader.Instance.MoveInput;

            rigidbody2D.velocity = new Vector2(moveInput.x * movementSpeed, rigidbody2D.velocity.y);
        }
        
        public void Move(Rigidbody rigidbody, float movementSpeed) {
            Vector2 moveInput = InputReader.Instance.MoveInput;

            rigidbody.velocity = new Vector3(moveInput.x * movementSpeed, rigidbody.velocity.y, moveInput.y * movementSpeed);
        }

        public Vector2 MovementInput() {
            return InputReader.Instance.MoveInput;
        }
    }
}
