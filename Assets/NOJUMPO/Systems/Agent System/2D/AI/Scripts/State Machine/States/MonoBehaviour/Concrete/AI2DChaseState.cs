using System.Collections;
using Nojumpo.AudioEventSystem;
using Nojumpo.Utils;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DChaseState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float attackDelay = 1.0f;
        [SerializeField] SimpleAudioEventSO runAudioEvent;

        bool _canAttack = true;

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _movementSpeed = _agent2DData.m_RunningSpeed;
        }

        public override void Tick() {
            HandleMovement();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            if (IsPlayerDead())
            {
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
                return;
            }
            
            CheckIfPathBlocked();

            if (!(DistanceToPlayer() > 1.00f))
            {
                _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;

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

        protected override void OnAnimationEvent() {
            runAudioEvent.Play();
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