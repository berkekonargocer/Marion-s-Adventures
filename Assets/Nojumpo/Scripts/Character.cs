using System;
using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public abstract class Character : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected bool canMove;
        [SerializeField] protected float movementSpeed = 10.0f;
        
        [field: SerializeField] public CharacterAnimator characterAnimator { get; set; }

        Rigidbody2D _rigidbody2D;

        CharacterStateMachine _characterStateMachine;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void OnEnable() {
            SetComponents();
        }
        
        protected virtual void Awake() {
            _characterStateMachine = new CharacterStateMachine();
        }

        protected virtual void Update() {
            _characterStateMachine.CurrentCharacterState.Update();
        }

        protected virtual void FixedUpdate() {
            _characterStateMachine.CurrentCharacterState.FixedUpdate();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        protected virtual void SetComponents() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected virtual void HandleMovement() {
            Vector2 moveInput = InputReader.Instance.MoveInput;
            _rigidbody2D.velocity = new Vector2(moveInput.x * movementSpeed, _rigidbody2D.velocity.y);
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
