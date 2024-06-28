using Cysharp.Threading.Tasks;
using Nojumpo.AudioEventSystem;
using Nojumpo.Utils;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DChaseState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float stopChaseDelay = 1.5f;
        [SerializeField] float attackDelay = 1.0f;

        [SerializeField] AudioSource animationEventAudioSource;
        [SerializeField] SimpleAudioEventSO runAudioEvent;

        bool _canAttack = true;
        bool _stopChasingTaskBusy = false;

        CancellationTokenSource _chaseCancellationTokenSource;

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            
            _stopChasingTaskBusy = false;
            _movementSpeed = _agent2DData.m_RunningSpeed;
            _playerDamageable.onDie += StopChasing;
        }

        public override void Tick() {
            TurnFaceToPlayer();

            if (!CanReachToPlayer() && !_stopChasingTaskBusy)
            {
                _chaseCancellationTokenSource = new CancellationTokenSource();
                StopChasingTask(_chaseCancellationTokenSource.Token).Forget();
                return;
            }

            if (CanReachToPlayer() && _stopChasingTaskBusy)
            {
                CancelStopChasingTask();
            }

            if (CheckIfInAttackRange())
                return;

            HandleMovement();
        }

        public override void OnExitState() {
            base.OnExitState();

            _playerDamageable.onDie -= StopChasing;
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
                StopChasing();
            }
        }

        protected override void OnAnimationEvent() {
            runAudioEvent.Play(animationEventAudioSource);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        float DistanceToPlayer() {
            return Vector2.Distance(transform.position, _playerTransform.position);
        }

        float VerticalDistanceToPlayer() {
            return transform.position.y - _playerTransform.position.y;
        }

        bool CanReachToPlayer() {
            if (DistanceToPlayer() > 6)
                return false;

            if (VerticalDistanceToPlayer() < -1.5f || VerticalDistanceToPlayer() > 1.5)
                return false;

            return true;
        }
        void StopChasing() {
            _stopChasingTaskBusy = false;
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
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
            if (DistanceToPlayer() > 1.00f)
            {
                _ai2DStateMachine.m_Animator.PlayAnimation(AgentAnimationState.RUN);
                return false;
            }

            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;

            if (!_canAttack)
            {
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

        async UniTask StopChasingTask(CancellationToken cancellationToken) {
            _stopChasingTaskBusy = true;

            try
            {
                await UniTask.WaitForSeconds(stopChaseDelay, cancellationToken: cancellationToken);

                if (!CanReachToPlayer())
                    StopChasing();
            }
            catch (OperationCanceledException)
            {
                _stopChasingTaskBusy = false;
            }
        }

        void CancelStopChasingTask() {
            _chaseCancellationTokenSource?.Cancel();
            _chaseCancellationTokenSource?.Dispose();
            _chaseCancellationTokenSource = null;
        }
    }
}