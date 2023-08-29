using Nojumpo.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo
{
    public abstract class Agent2DStateBase : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected InputReader inputReader;

        [SerializeField] protected Agent2DStateBase jumpState;
        [SerializeField] protected Agent2DStateBase moveState;
        [SerializeField] protected Agent2DStateBase fallState;
        

        [SerializeField] protected string animatorStateParameter = "";

        protected Agent2DBase _agent2D;

        public UnityEvent OnEnter, OnExit;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            inputReader.onJumpInputPressed += HandleJumpPressed;
            inputReader.onJumpInputReleased += HandleJumpReleased;
        }

        void OnDisable() {
            inputReader.onJumpInputPressed -= HandleJumpPressed;
            inputReader.onJumpInputReleased -= HandleJumpReleased;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void HandleMovement() {

        }

        protected virtual void HandleJumpPressed() {
            if (_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(jumpState);
            }
        }

        protected virtual void HandleJumpReleased() {

        }

        protected virtual void HandleAttack() {

        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(Agent2DBase agent2D) {
            _agent2D = agent2D;
        }

        public virtual void Enter() {
            _agent2D.Animator.PlayAnimation(animatorStateParameter);
            OnEnter?.Invoke();
        }

        public virtual void StateUpdate() {

        }

        public virtual void StateFixedUpdate() {

        }

        public virtual void Exit() {
            OnExit?.Invoke();
        }

    }
}
