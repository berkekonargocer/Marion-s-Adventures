using NOJUMPO.DamageableSystem;
using NOJUMPO.WeaponSystem;
using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public abstract class Agent2D : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DData agent2DData;
        
        public Agent2DMovementData m_AgentMovementData { get; private set; }
        public Rigidbody2D m_Rigidbody2D { get; protected set; }
        public AgentAnimator m_Animator { get; protected set; }
        public Agent2DRenderer m_Renderer { get; protected set; }
        public Agent2DGroundDetector m_GroundDetector { get; protected set; }
        public Agent2DClimbableDetector m_ClimbableDetector { get; protected set; }
        public Damageable m_AgentDamageable { get; private set; }
        public WeaponManager m_AgentWeapon { get; private set; }
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
        }

        protected virtual void Update() {
            m_GroundDetector.CheckIsGrounded();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            m_AgentMovementData = new Agent2DMovementData();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Animator = GetComponentInChildren<AgentAnimator>();
            m_Renderer = GetComponent<Agent2DRenderer>();
            m_GroundDetector = GetComponentInChildren<Agent2DGroundDetector>();
            m_ClimbableDetector = GetComponentInChildren<Agent2DClimbableDetector>();
            m_AgentWeapon = GetComponentInChildren<WeaponManager>();
            m_AgentDamageable = GetComponent<Damageable>();
        }
    }
}