using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.StateMachine
{
    public abstract class State : MonoBehaviour, IState
    {
        // -------------------------------- FIELDS ---------------------------------
        [Space]
        [SerializeField] protected string animatorStateParameter = "";
        [Space]
        public UnityEvent OnEnter, OnExit;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public abstract void OnEnterState();
        public abstract void Tick();
        public abstract void FixedTick();
        public abstract void OnExitState();
        
    }
}