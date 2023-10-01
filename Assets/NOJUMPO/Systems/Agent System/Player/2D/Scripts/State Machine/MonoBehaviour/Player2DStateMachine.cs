using Nojumpo.NJInputSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    [DisallowMultipleComponent]
    public class Player2DStateMachine : Agent2D
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public InputReader m_InputReader { get; protected set; }

        public Player2DState currentState;
        public Player2DState previousState;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();
            InitializePlayer2D();
        }

        protected override void Start() {
            ChangeState(m_StateFactory.m_Idle);
        }

        protected override void Update() {
            base.Update();
            currentState.Tick();
        }

        protected override void FixedUpdate() {
            currentState.FixedTick();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Player2DState newState) {
            if (currentState != null)
                currentState.OnExitState();

            previousState = currentState;
            currentState = newState;
            currentState.OnEnterState();

            DisplayState();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected void InitializePlayer2D() {
            m_StateFactory.InitializeStates(this, agent2DData);
        }

        protected void DisplayState() {
            stateName = currentState.GetType().ToString();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}