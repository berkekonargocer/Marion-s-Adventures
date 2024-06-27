using Nojumpo.AudioEventSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DPatrolState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] LayerMask playerLayerMask;
        [SerializeField] float playerCheckRayLength;

        [SerializeField] AudioSource animationEventAudioSource;
        [SerializeField] SimpleAudioEventSO runAudioEvent;

        RaycastHit2D[] forwardCheckHits = new RaycastHit2D[1];
        RaycastHit2D[] backwardCheckHits = new RaycastHit2D[1];

        [Space]
        [Header("GIZMOS")]
        [SerializeField] bool showGizmos = true;
        [SerializeField] Color raycastColor = Color.green;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnDrawGizmos() {
            Gizmos.color = raycastColor;
            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            Gizmos.DrawRay(raycastPosition, -1 * playerCheckRayLength * objectTransform.right);
            Gizmos.DrawRay(raycastPosition, transform.right * playerCheckRayLength);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

        public override void OnEnterState() {
            base.OnEnterState();
            _movementSpeed = _agent2DData.m_WalkingSpeed;
        }

        public override void Tick() {
            if (IsEnemyNearby())
            {
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Chase);
                return;
            }

            HandleMovement();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            CheckIfPathBlocked();

            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
            CalculateVelocity();
            SetVelocity();
        }

        protected override void OnAnimationEvent() {
            if (runAudioEvent == null)
                return;

            runAudioEvent.Play(animationEventAudioSource);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        bool IsEnemyNearby() {
            if (IsPlayerDead())
                return false;

            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            int forwardHits = Physics2D.RaycastNonAlloc(raycastPosition, objectTransform.right, forwardCheckHits, playerCheckRayLength, playerLayerMask);
            int backwardHits = Physics2D.RaycastNonAlloc(raycastPosition, transform.right * -1, backwardCheckHits, playerCheckRayLength, playerLayerMask);

            if (forwardHits <= 0 && backwardHits <= 0)
                return false;

            return true;
        }
    }
}