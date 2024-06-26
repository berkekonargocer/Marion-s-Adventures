using Nojumpo.NJInputSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    [DisallowMultipleComponent]
    public class Player2DStateMachine : Agent2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public InputReader m_InputReader { get; protected set; }
        
        [SerializeField] Player2DState initialState;
        
        public Player2DStateFactory m_StateFactory { get; protected set; }

        [Space]
        [SerializeField] string stateName = "";

        Player2DState _currentState;
        Player2DState _previousState;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();
            InitializePlayer2D();
        }

        protected virtual void Start() {
            InitializeStateMachine();
        }

        protected override void Update() {
            base.Update();
            _currentState.Tick();
        }

        protected virtual void FixedUpdate() {
            _currentState.FixedTick();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Player2DState newState) {
            _currentState.OnExitState();

            _previousState = _currentState;
            _currentState = newState;
            _currentState.OnEnterState();

            DisplayState();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected void InitializePlayer2D() {
            m_StateFactory.InitializeStates(this, agent2DData);
        }

        protected void DisplayState() {
            stateName = _currentState.GetType().ToString();
        }

        protected override void SetComponents() {
            base.SetComponents();
            m_StateFactory = GetComponentInChildren<Player2DStateFactory>();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void InitializeStateMachine() {
            _currentState = initialState;
            _currentState.OnEnterState();
        }
    }
}