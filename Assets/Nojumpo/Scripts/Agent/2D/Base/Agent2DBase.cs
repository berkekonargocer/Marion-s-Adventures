using UnityEngine;

namespace Nojumpo
{
    public abstract class Agent2DBase : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public AgentAnimator agentAnimator { get; set; }

        [SerializeField] Agent2DIdleState idleState;
        
        public Rigidbody2D AgentRigidbody2D { get; protected set; }

        [Header("State Debug")]
        public Agent2DStateBase currentState = null;
        public Agent2DStateBase previousState = null;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
            Agent2DStateBase[] agent2DStates = GetComponentsInChildren<Agent2DStateBase>();

            foreach (var agent2DState in agent2DStates)
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
            AgentRigidbody2D = GetComponent<Rigidbody2D>();
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
