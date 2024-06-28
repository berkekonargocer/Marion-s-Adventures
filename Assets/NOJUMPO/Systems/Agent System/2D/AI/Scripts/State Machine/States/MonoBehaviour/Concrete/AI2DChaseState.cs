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

        [SerializeField] AudioSource animationEventAudioSource;
        [SerializeField] SimpleAudioEventSO runAudioEvent;

        bool _canAttack = true;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _movementSpeed = _agent2DData.m_RunningSpeed;
        }

        public override void Tick() {
            TurnFaceToPlayer();
            
            if (CheckIfStopChasing())
                return;
            
            if (CheckIfInAttackRange())
                return;

            HandleMovement();
        }

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleMovement() {
            CheckIfPathBlocked();

            CalculateVelocity();
            SetVelocity();
        }
        
        protected override void CheckIfPathBlocked() {
            if (_ai2DStateMachine.m_AI2DPathBlockDetector.IsPathBlocked)
            {
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
            }
        }

        protected override void OnAnimationEvent() {
            runAudioEvent.Play(animationEventAudioSource);
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        bool CheckIfStopChasing() {
            if (!IsPlayerDead())
                return false;
            
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
            return true;
        }
        
        float DistanceToPlayer() {
            return Vector2.Distance(transform.position, _playerTransform.position);
        }

        void TurnFaceToPlayer() {
            if (_playerTransform.position.x > transform.position.x)
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = 1;
            }
            else
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = -1;
            }
            
            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
        }
        
        bool CheckIfInAttackRange() {
            if (DistanceToPlayer() > 1.00f) {
                _ai2DStateMachine.m_Animator.PlayAnimation(AgentAnimationState.RUN);
                return false;
            }

            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;

            if (!_canAttack) {
                _ai2DStateMachine.m_Animator.PlayAnimation(AgentAnimationState.IDLE);
                return true;
            }
            
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Attack);
            StartCoroutine(nameof(AttackDelay));

            return true;
        }

        IEnumerator AttackDelay() {
            _canAttack = false;

            yield return NJUtils.GetWait(attackDelay);

            _canAttack = true;
        }
    }
}