using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo
{
    public abstract class Agent2DStateBase : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        protected Agent2DBase _agent2D;
        
        public UnityEvent OnEnter, OnExit;


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(Agent2DBase agent2D) {
            this._agent2D = agent2D;
        }
        
        public virtual void EnterState() {
            this.OnEnter?.Invoke();
        }
        
        public virtual void Update() {
            
        }

        public virtual void FixedUpdate(){
            
        }
        
        public virtual void ExitState() {
            this.OnExit?.Invoke();
        }

        protected virtual void HandleMovement() {
            
        }

        protected virtual void HandleJumpPressed() {
            
        }

        protected virtual void HandleJumpReleased() {
            
        }
        
        protected virtual void HandleAttack() {
            
        }
    }
}