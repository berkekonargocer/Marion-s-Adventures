using UnityEngine;

namespace Nojumpo.AgentSystem
{
    [DisallowMultipleComponent]
    public class AI2DStateMachine : Agent2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AI2DState bootUpState;

        public AI2DStateFactory m_StateFactory { get; protected set; }
        public AI2DPathBlockDetector m_AI2DPathBlockDetector { get; protected set; }

        [Space]
        [SerializeField] string stateName = "";

        AI2DState _currentState;
        AI2DState _previousState;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();
            InitializeAI2D();
        }

        protected override void Start() {
            BootUpStateMachine();
        }

        protected override void Update() {
            base.Update();
            _currentState.Tick();
        }

        protected override void FixedUpdate() {
            _currentState.FixedTick();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(AI2DState newState) {
            _currentState.OnExitState();

            _previousState = _currentState;
            _currentState = newState;
            _currentState.OnEnterState();

            DisplayState();
        }

        public void TransitionToPreviousState() {
            ChangeState(_previousState);
        }

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void InitializeAI2D() {
            m_StateFactory.InitializeStates(this, agent2DData);
        }

        protected void DisplayState() {
            stateName = _currentState.GetType().ToString();
        }

        protected override void SetComponents() {
            base.SetComponents();
            m_StateFactory = GetComponentInChildren<AI2DStateFactory>();
            m_AI2DPathBlockDetector = GetComponentInChildren<AI2DPathBlockDetector>();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void BootUpStateMachine() {
            _currentState = bootUpState;
            _currentState.OnEnterState();
        }
    }
}