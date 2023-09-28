using Nojumpo.DamageableSystem;
using Nojumpo.ScriptableObjects;
using Nojumpo.WeaponSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Agent2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DData agent2DData;
        [field: SerializeField] public InputReader m_InputReader { get; protected set; }

        [SerializeField] Agent2DIdleState idleState;
        
        public Rigidbody2D m_Rigidbody2D { get; protected set; }
        public AgentAnimator m_Animator { get; protected set; }
        public Agent2DRenderer m_Renderer { get; protected set; }
        public Agent2DGroundDetector m_GroundDetector { get; protected set; }
        public Agent2DClimbableDetector m_ClimbableDetector { get; protected set; }
        public StateFactory m_StateFactory { get; protected set; }
        public WeaponManager m_AgentWeapon { get; private set; }

        Damageable _agentDamageable;

        [Header("State Debug")]
        public Agent2DState currentState;
        public Agent2DState previousState;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
            m_StateFactory.InitializeStates(this, agent2DData);
        }

        protected void Start() {
            ChangeState(idleState);
        }

        protected void Update() {
            m_GroundDetector.CheckIsGrounded();
            currentState.StateUpdate();
        }

        protected virtual void FixedUpdate() {
            currentState.StateFixedUpdate();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Animator = GetComponentInChildren<AgentAnimator>();
            m_Renderer = GetComponent<Agent2DRenderer>();
            m_GroundDetector = GetComponentInChildren<Agent2DGroundDetector>();
            m_ClimbableDetector = GetComponentInChildren<Agent2DClimbableDetector>();
            m_StateFactory = GetComponentInChildren<StateFactory>();
            m_AgentWeapon = GetComponentInChildren<WeaponManager>();
            _agentDamageable = GetComponent<Damageable>();
        }

        protected void DisplayState() {
            stateName = currentState.GetType().ToString();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(Agent2DState newState) {
            if (currentState != null)
                currentState.Exit();

            previousState = currentState;
            currentState = newState;
            currentState.Enter();

            DisplayState();
        }
    }
}