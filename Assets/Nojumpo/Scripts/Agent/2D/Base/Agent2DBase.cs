using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
{
    public abstract class Agent2DBase : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public AgentAnimator Animator { get; set; }

        [SerializeField] Agent2DIdleState idleState;
        [SerializeField] Agent2DStateBase[] States;
        public Rigidbody2D RigidBody2D { get; protected set; }
        
        [Header("State Debug")]
        public Agent2DStateBase currentState;
        public Agent2DStateBase previousState;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();

            foreach (Agent2DStateBase agent2DState in States)
            {
                agent2DState.Initialize(this);
            }
        }

        protected void Start() {
            ChangeState(idleState);
        }

        protected void Update() {
            currentState.StateUpdate();
        }

        protected virtual void FixedUpdate() {
            currentState.StateFixedUpdate();
        }
        
        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            RigidBody2D = GetComponent<Rigidbody2D>();
        }

        protected void DisplayState() {
            stateName = currentState.GetType().ToString();
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Agent2DStateBase newState) {
            if (currentState != null)
                currentState.Exit();
            
            previousState = currentState;
            currentState = newState;
            currentState.Enter();

            DisplayState();
        }
    }
}
