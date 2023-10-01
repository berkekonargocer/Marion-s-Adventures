using Nojumpo.DamageableSystem;
using Nojumpo.ScriptableObjects;
using Nojumpo.WeaponSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public abstract class Agent2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DData agent2DData;

        public Rigidbody2D m_Rigidbody2D { get; protected set; }
        public AgentAnimator m_Animator { get; protected set; }
        public Agent2DRenderer m_Renderer { get; protected set; }
        public Agent2DGroundDetector m_GroundDetector { get; protected set; }
        public Agent2DClimbableDetector m_ClimbableDetector { get; protected set; }
        public Player2DStateFactory m_StateFactory { get; protected set; }
        public Damageable m_AgentDamageable { get; private set; }
        public WeaponManager m_AgentWeapon { get; private set; }
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
        }

        protected virtual void Start() {

        }

        protected virtual void Update() {
            m_GroundDetector.CheckIsGrounded();
        }

        protected virtual void FixedUpdate() {
            
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Animator = GetComponentInChildren<AgentAnimator>();
            m_Renderer = GetComponent<Agent2DRenderer>();
            m_GroundDetector = GetComponentInChildren<Agent2DGroundDetector>();
            m_ClimbableDetector = GetComponentInChildren<Agent2DClimbableDetector>();
            m_StateFactory = GetComponentInChildren<Player2DStateFactory>();
            m_AgentWeapon = GetComponentInChildren<WeaponManager>();
            m_AgentDamageable = GetComponent<Damageable>();
        }
    }
}