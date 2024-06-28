using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NOJUMPO.NJInputSystem
{
    [CreateAssetMenu(fileName = "NewInputReader", menuName = "Nojumpo/Scriptable Objects/Input Reading System/New Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
    {
#if UNITY_EDITOR
        [TextArea]
        [SerializeField] string developerDescription = "CREATE ONE FOR EACH PLAYER";

#endif

        // -------------------------------- FIELDS ---------------------------------
        GameInput _gameInputScheme;

        public Vector2 MovementVector { get; private set; }

        public event Action<Vector2> OnMovementInputPressed;
        public event Action OnInteractionInputPressed;
        public event Action OnInteractionInputReleased;
        public event Action OnJumpInputPressed;
        public event Action OnJumpInputReleased;
        public event Action OnAttackInputPressed;
        public event Action OnChangeWeaponInputPressed;


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
            OnMovementInputPressed?.Invoke(MovementVector);
        }

        public void OnInteractButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Performed)
            {
                OnInteractionInputPressed?.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                OnInteractionInputReleased?.Invoke();
            }
        }

        public void OnJumpButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                OnJumpInputPressed?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                OnJumpInputReleased?.Invoke();
            }
        }

        public void OnAttackButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                OnAttackInputPressed?.Invoke();
            }
        }

        public void OnChangeWeaponButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                OnChangeWeaponInputPressed?.Invoke();
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