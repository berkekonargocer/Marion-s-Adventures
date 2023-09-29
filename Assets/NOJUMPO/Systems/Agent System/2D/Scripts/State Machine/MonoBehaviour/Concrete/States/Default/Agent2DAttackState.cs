using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    public class Agent2DAttackState : Agent2DState
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
            Vector3 weaponPosition = _agent2D.m_AgentWeapon.transform.position;
            _agent2D.m_AgentWeapon.GetCurrentWeapon().DrawWeaponGizmo(weaponPosition, _attackDirection);
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.m_AgentWeapon.ToggleWeaponVisibility(true);

            Transform agent2DTransform = _agent2D.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);

            if (_agent2D.m_GroundDetector.IsGrounded)
                _agent2D.m_Rigidbody2D.velocity = Vector2.zero;
        }

        public override void StateUpdate() {
            // Prevent Update Method While Attacking
        }

        public override void StateFixedUpdate() {
            // Prevent Fixed Update Method While Attacking
        }
        
        public override void Exit() {
            base.Exit();
            _agent2D.m_AgentWeapon.ToggleWeaponVisibility(false);
            _agent2D.m_Animator.onAnimationEvent -= InvokeAttack;
            _agent2D.m_Animator.onAnimationEndEvent -= ChangeStateToIdle;
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
            _agent2D.m_Animator.onAnimationEvent -= InvokeAttack;
            _agent2D.m_AgentWeapon.GetCurrentWeapon().PerformAttack(_agent2D,_attackDirection);
            OnAttack?.Invoke();
        }

        void ChangeStateToIdle() {
            _agent2D.m_Animator.onAnimationEndEvent -= ChangeStateToIdle;

            _agent2D.ChangeState(_agent2D.m_GroundDetector.IsGrounded ? _agent2D.m_StateFactory.m_Idle : _agent2D.m_StateFactory.m_Fall);
        }
    }
}