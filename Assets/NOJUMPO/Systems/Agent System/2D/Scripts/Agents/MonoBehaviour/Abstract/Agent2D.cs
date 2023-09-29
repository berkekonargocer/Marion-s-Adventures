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

        public Rigidbody2D m_Rigidbody2D { get; protected set; }
        public AgentAnimator m_Animator { get; protected set; }
        public Agent2DRenderer m_Renderer { get; protected set; }
        public Agent2DGroundDetector m_GroundDetector { get; protected set; }
        public Agent2DClimbableDetector m_ClimbableDetector { get; protected set; }
        public PlayerStateFactory m_StateFactory { get; protected set; }
        public Damageable m_AgentDamageable { get; private set; }
        public WeaponManager m_AgentWeapon { get; private set; }


        [Header("State Debug")]
        public Agent2DState currentState;
        public Agent2DState previousState;
        [Space]
        [SerializeField] string stateName = "";


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
            InitializeAgent();
        }

        protected void Start() {
            ChangeState(m_StateFactory.m_Idle);
        }

        protected void Update() {
            m_GroundDetector.CheckIsGrounded();
            currentState.StateUpdate();
        }

        protected virtual void FixedUpdate() {
            currentState.StateFixedUpdate();
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
        
        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Animator = GetComponentInChildren<AgentAnimator>();
            m_Renderer = GetComponent<Agent2DRenderer>();
            m_GroundDetector = GetComponentInChildren<Agent2DGroundDetector>();
            m_ClimbableDetector = GetComponentInChildren<Agent2DClimbableDetector>();
            m_StateFactory = GetComponentInChildren<PlayerStateFactory>();
            m_AgentWeapon = GetComponentInChildren<WeaponManager>();
            m_AgentDamageable = GetComponent<Damageable>();
        }

        protected void InitializeAgent() {
            m_StateFactory.InitializeStates(this, agent2DData);
        }

        protected void DisplayState() {
            stateName = currentState.GetType().ToString();
        }
    }
}