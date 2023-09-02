using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewInputReader", menuName = "Nojumpo/Scriptable Objects/Game Input/New Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
    {

#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string _developerDescription = "CREATE ONE FOR EACH PLAYER";

#endif

        // -------------------------------- FIELDS ---------------------------------
        GameInput _gameInputScheme;

        public Vector2 MovementVector { get; private set; }

        public delegate void OnMovementInputPressed(Vector2 movementVector);
        public OnMovementInputPressed onMovementInputPressed;

        public delegate void OnInteractionInputPressed();
        public event OnInteractionInputPressed onInteractionInputPressed;

        public delegate void OnInteractionInputReleased();
        public event OnInteractionInputReleased onInteractionInputReleased;

        public delegate void OnJumpInputPressed();
        public event OnJumpInputPressed onJumpInputPressed;

        public delegate void OnJumpInputReleased();
        public event OnJumpInputReleased onJumpInputReleased;

        public delegate void OnAttackInputPressed(float damageAmount);
        public event OnAttackInputPressed onAttackInputPressed;

        public delegate void OnHealInputPressed(float healAmount);
        public event OnHealInputPressed onHealInputPressed;
        
        public delegate void OnChangeWeaponInputPressed();
        public event OnChangeWeaponInputPressed onChangeWeaponInputPressed;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            if (_gameInputScheme == null)
            {
                _gameInputScheme = new GameInput();

                _gameInputScheme.Player.SetCallbacks(this);
                _gameInputScheme.UI.SetCallbacks(this);

                SetPlayerInput();
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnMove(InputAction.CallbackContext context) {
            MovementVector = context.ReadValue<Vector2>();
            onMovementInputPressed?.Invoke(MovementVector);
        }

        public void OnInteractButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Performed)
            {
                onInteractionInputPressed?.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                onInteractionInputReleased?.Invoke();
            }
        }

        public void OnJumpButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                onJumpInputPressed?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                onJumpInputReleased?.Invoke();
            }
        }

        public void OnAttackButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                onAttackInputPressed?.Invoke(10);
            }
        }
        
        public void OnHealButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                onHealInputPressed?.Invoke(75);
            }
        }
        
        public void OnChangeWeaponButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                onChangeWeaponInputPressed?.Invoke();
            }
        }


        #region UI Input
        public void OnResumeGame(InputAction.CallbackContext context) {
            // throw new System.NotImplementedException();
        }
        #endregion


        public void SetPlayerInput() {
            _gameInputScheme.UI.Disable();
            _gameInputScheme.Player.Enable();
        }

        public void SetUIInput() {
            _gameInputScheme.Player.Disable();
            _gameInputScheme.UI.Enable();

        }
    }
}
