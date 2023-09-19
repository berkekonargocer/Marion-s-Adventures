using System;
using Nojumpo.DamageableSystem;
using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class Agent2DBase : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DData agent2DData;
        [field: SerializeField] public InputReader GameInputReader { get; protected set; }

        [SerializeField] Agent2DIdleState idleState;

        public Rigidbody2D RigidBody2D { get; protected set; }
        public AgentAnimator Animator { get; protected set; }
        public Agent2DGroundDetector GroundDetector { get; protected set; }
        public Agent2DClimbableDetector ClimbableDetector { get; protected set; }

        [Header("State Debug")]
        public Agent2DStateBase currentState;
        public Agent2DStateBase previousState;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
            SetStates();
        }

        protected void Start() {
            ChangeState(idleState);
        }

        protected void Update() {
            GroundDetector.CheckIsGrounded();
            currentState.StateUpdate();
        }

        protected virtual void FixedUpdate() {
            currentState.StateFixedUpdate();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            RigidBody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<AgentAnimator>();
            GroundDetector = GetComponentInChildren<Agent2DGroundDetector>();
            ClimbableDetector = GetComponentInChildren<Agent2DClimbableDetector>();
        }

        protected virtual void SetStates() {
            Agent2DStateBase[] agent2DStates = GetComponentsInChildren<Agent2DStateBase>();

            foreach (Agent2DStateBase agent2DState in agent2DStates)
            {
                agent2DState.Initialize(this, agent2DData);
            }
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