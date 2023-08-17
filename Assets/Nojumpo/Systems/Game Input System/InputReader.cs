using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewInputReader", menuName = "Nojumpo/Scriptable Objects/Game Input/New Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
    {

#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string _developerDescription = "ONLY CREATE 1 AND PUT TO RESOURCES FOLDER";

#endif
        // -------------------------------- FIELDS ---------------------------------
        static InputReader _inputReader;
        
        public static InputReader Instance {
            get
            {
                if (_inputReader == null)
                {
                    _inputReader = Resources.Load<InputReader>("Input Reader");
                }
                return _inputReader;
            }
        }

        GameInput _gameInputScheme;
        
        public Vector2 MovementVector { get; private set; }

        public bool InteractionInputPressedThisFrame { get; private set; }
        public bool InteractionInputReleasedThisFrame { get; private set; }

        public bool JumpInputPressedThisFrame { get; private set; }
        public bool JumpInputReleasedThisFrame { get; private set; }
        
        public bool AttackButtonPressedThisFrame { get; private set; }
        public bool ChangeWeaponButtonPressedThisFrame { get; private set; }
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            Debug.Log("Input Reader Init");
            if (_gameInputScheme == null)
            {
                Debug.Log("Input Reader Is Null Setting New GameInput");
                _gameInputScheme = new GameInput();

                _gameInputScheme.Player.SetCallbacks(this);
                _gameInputScheme.UI.SetCallbacks(this);

                SetPlayerInput();
            }
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnMove(InputAction.CallbackContext context) {
            Debug.Log("OnMove");
            MovementVector = context.ReadValue<Vector2>();
        }

        public async void OnInteractButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                InteractionInputPressedThisFrame = true;
                await Task.Yield();
                InteractionInputPressedThisFrame = false;
            }
            
            if (context.phase == InputActionPhase.Canceled)
            {
                InteractionInputReleasedThisFrame = true;
                await Task.Yield();
                InteractionInputReleasedThisFrame = false;
            }
        }

        public async void OnJumpButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                Debug.Log("OnJumpStart");

                JumpInputPressedThisFrame = true;
                await Task.Yield();
                JumpInputPressedThisFrame = false;
            }
            
            if (context.phase == InputActionPhase.Canceled)
            {
                Debug.Log("OnJumpCanceled");

                JumpInputReleasedThisFrame = true;
                await Task.Yield();
                JumpInputReleasedThisFrame = false;
            }
        }

        public async void OnAttackButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                Debug.Log("Attack");
                AttackButtonPressedThisFrame = true;
                await Task.Yield();
                AttackButtonPressedThisFrame = false;
            }
        }

        public async void OnChangeWeaponButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Started)
            {
                ChangeWeaponButtonPressedThisFrame = true;
                Debug.Log("Change Weapon");
                await Task.Yield();
                ChangeWeaponButtonPressedThisFrame = false;
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
