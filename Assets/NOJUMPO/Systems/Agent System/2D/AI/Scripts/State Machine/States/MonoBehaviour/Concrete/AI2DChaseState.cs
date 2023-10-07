using System.Collections;
using Nojumpo.Utils;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DChaseState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float attackDelay = 2.0f;

        Transform _playerTransform;

        bool _canAttack = true;


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
            _movementSpeed = _agent2DData.m_RunningSpeed;
            _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        public override void Tick() {
            HandleMovement();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            CheckIfPathBlocked();

            if (!(DistanceToPlayer() > 1.00f))
            {
                if (!_canAttack)
                    return;
                
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Attack);
                StartCoroutine(nameof(AttackDelay));
                
                return;
            }

            if (_playerTransform.position.x > transform.position.x)
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
            return Vector2.Distance(transform.position, _playerTransform.position);
        }

        IEnumerator AttackDelay() {
            _canAttack = false;

            yield return NJUtils.GetWait(attackDelay);

            _canAttack = true;
        }
    }
}