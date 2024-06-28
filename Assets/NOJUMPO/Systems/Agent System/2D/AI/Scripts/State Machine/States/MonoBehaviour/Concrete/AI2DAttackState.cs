using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public class AI2DAttackState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioSource attackSFXSource;

        protected Vector2 _attackDirection;


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        public override void OnEnterState() {
            base.OnEnterState();

            _playerDamageable.OnDie += StopAttacking;

            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;

            int movementDirection;

            if (_playerTransform.position.x > transform.position.x)
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = 1;
                movementDirection = 1;
            }
            else
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = -1;
                movementDirection = -1;
            }

            _ai2DStateMachine.m_Renderer.FaceDirection(movementDirection);

            Transform agent2DTransform = _ai2DStateMachine.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);
        }

        protected override void OnAnimationEvent() {
            _ai2DStateMachine.m_AgentWeapon.GetCurrentWeapon().PerformAttack(_ai2DStateMachine, _attackDirection, attackSFXSource);
        }

        protected override void OnAnimationEndEvent() {
            if (_playerDamageable.IsDead)
            {
                _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
                return;
            }

            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Chase);
        }

        public override void OnExitState() {
            base.OnExitState();

            _playerDamageable.OnDie -= StopAttacking;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void StopAttacking() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Patrol);
        }
    }
}