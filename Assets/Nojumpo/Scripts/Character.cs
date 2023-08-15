using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Character : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected bool canMove;
        [SerializeField] protected float movementSpeed = 10.0f;
        
        [field: SerializeField] public CharacterAnimator characterAnimator { get; set; }

        Rigidbody2D _rigidbody2D;

        CharacterStateMachine _characterStateMachine;
        IdleState _characterIdleState;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            SetComponents();
        }

        void OnDisable() {

        }

        void Awake() {
            _characterStateMachine = new CharacterStateMachine();
            _characterIdleState = new IdleState(this, _characterStateMachine);
        }

        void Start() {
            _characterStateMachine.Initialize(_characterIdleState);
        }

        void FixedUpdate() {
            HandleMovement();
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
