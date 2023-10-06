namespace Nojumpo.AgentSystem
{
    public class AI2DPatrolState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick(float deltaTime) {
            HandleMovement();
        }
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------

        protected override void HandleMovement() {
            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
            CalculateVelocity();
            SetVelocity();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}