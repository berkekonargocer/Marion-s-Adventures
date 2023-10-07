using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DPatrolState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask playerLayerMask;
        [SerializeField] float playerCheckRayLength;
        
        RaycastHit2D[] forwardCheckHits = new RaycastHit2D[1];
        RaycastHit2D[] backwardCheckHits = new RaycastHit2D[1];

        [Space]
        [Header("GIZMOS")]
        [SerializeField] bool showGizmos = true;
        [SerializeField] Color raycastColor = Color.green;
        
        
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

        void OnDrawGizmos() {
            Gizmos.color = raycastColor;
            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            Gizmos.DrawRay(raycastPosition, objectTransform.right * -1 * playerCheckRayLength);
            Gizmos.DrawRay(raycastPosition, transform.right * playerCheckRayLength);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Tick() {
            CheckForEnemy();
            HandleMovement();
        }
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------

        protected override void HandleMovement() {
            CheckIfPathBlocked();
            
            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
            CalculateVelocity();
            SetVelocity();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CheckForEnemy() {
            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            int forwardHits = Physics2D.RaycastNonAlloc(raycastPosition, objectTransform.right * -1, forwardCheckHits, playerCheckRayLength, playerLayerMask);
            int backwardHits = Physics2D.RaycastNonAlloc(raycastPosition, transform.right, backwardCheckHits, playerCheckRayLength, playerLayerMask);

            if (forwardHits > 0 || backwardHits > 0)
            {
                Debug.Log("PLAYER DETECTED");
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Chase);
            }
        }
    }
}