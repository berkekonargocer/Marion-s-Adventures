using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DChaseState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        Transform playerTransform;
        

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
        public override void OnEnterState() {
            base.OnEnterState();
            playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        public override void Tick() {
            HandleMovement();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            CheckIfPathBlocked();

            if (!(DistanceToPlayer() > 1.5f))
            {
                // Change Into Attack State
                return;
            }
                

            if (playerTransform.position.x > transform.position.x)
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = 1;
            }
            else
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = -1;
            }
                
            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
            CalculateVelocity();
            SetVelocity();

        }

        protected override void CheckIfPathBlocked() {
            if (_ai2DStateMachine.m_AI2DPathBlockDetector.IsPathBlocked)
            {
                // Stop Chasing
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
            }
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------

        float DistanceToPlayer() {
            return Vector2.Distance(transform.position, playerTransform.position);
        }
    }
}