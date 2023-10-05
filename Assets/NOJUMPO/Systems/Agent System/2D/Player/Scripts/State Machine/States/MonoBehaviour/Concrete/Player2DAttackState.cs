using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    public class Player2DAttackState : Player2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] bool showGizmos = true;
        public UnityEvent OnAttack;

        protected Vector2 _attackDirection;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnDrawGizmos() {
            if (!Application.isPlaying)
                return;

            if (!showGizmos)
                return;

            Gizmos.color = Color.red;
            Vector3 weaponPosition = _player2DStateMachine.m_AgentWeapon.transform.position;
            _player2DStateMachine.m_AgentWeapon.GetCurrentWeapon().DrawWeaponGizmo(weaponPosition, _attackDirection);
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _player2DStateMachine.m_AgentWeapon.ToggleWeaponVisibility(true);

            Transform agent2DTransform = _player2DStateMachine.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);

            if (_player2DStateMachine.m_GroundDetector.IsGrounded)
                _player2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
        }

        public override void Tick(float deltaTime) {
            // Prevent Update Method While Attacking
        }

        public override void FixedTick() {
            // Prevent Fixed Update Method While Attacking
        }
        
        public override void OnExitState() {
            base.OnExitState();
            _player2DStateMachine.m_AgentWeapon.ToggleWeaponVisibility(false);
            _player2DStateMachine.m_Animator.onAnimationEvent -= InvokeAttack;
            _player2DStateMachine.m_Animator.onAnimationEndEvent -= ChangeStateToIdle;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void HandleAttack() {
            // Prevent Attacking Again
        }

        protected override void HandleJumpPressed() {
            // Prevent Jumping While Attacking
        }
        
        protected override void OnAnimationEvent() {
            InvokeAttack();
        }

        protected override void OnAnimationEndEvent() {
            ChangeStateToIdle();
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void InvokeAttack() {
            _player2DStateMachine.m_Animator.onAnimationEvent -= InvokeAttack;
            _player2DStateMachine.m_AgentWeapon.GetCurrentWeapon().PerformAttack(_player2DStateMachine,_attackDirection);
            OnAttack?.Invoke();
        }

        void ChangeStateToIdle() {
            _player2DStateMachine.m_Animator.onAnimationEndEvent -= ChangeStateToIdle;

            _player2DStateMachine.ChangeState(_player2DStateMachine.m_GroundDetector.IsGrounded ? _player2DStateMachine.m_StateFactory.m_Idle : _player2DStateMachine.m_StateFactory.m_Fall);
        }
    }
}