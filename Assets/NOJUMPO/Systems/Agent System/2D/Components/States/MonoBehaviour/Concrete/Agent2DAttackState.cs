using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    public class Agent2DAttackState : Agent2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DIdleState idleState;

        public UnityEvent OnAttack;

        protected Vector2 _attackDirection;
        [SerializeField] bool showGizmos = true;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnDrawGizmos() {
            if (!Application.isPlaying)
                return;

            if (!showGizmos)
                return;

            Gizmos.color = Color.red;
            Vector3 weaponPosition = _agent2D.AgentWeapon.transform.position;
            _agent2D.AgentWeapon.GetCurrentWeapon().DrawWeaponGizmo(weaponPosition, _attackDirection);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void InvokeAttack() {
            _agent2D.Animator.onAnimationEvent -= InvokeAttack;
            _agent2D.AgentWeapon.GetCurrentWeapon().PerformAttack(_agent2D,_attackDirection);
            OnAttack?.Invoke();
        }

        void ChangeStateToIdle() {
            _agent2D.Animator.onAnimationEndEvent -= ChangeStateToIdle;

            if (_agent2D.GroundDetector.IsGrounded)
            {
                _agent2D.ChangeState(idleState);
            }
            else
            {
                _agent2D.ChangeState(fallState);
            }
        }

        protected override void HandleAttack() {
            // Prevent Attacking Again
        }

        protected override void HandleJumpPressed() {
            // Prevent Jumping While Attacking
        }

        protected override void HandleJumpReleased() {
            // Prevent This Method Call
        }

        protected override void HandleMovement() {
            // Prevent Moving While Attacking
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.AgentWeapon.ToggleWeaponVisibility(true);

            Transform agent2DTransform = _agent2D.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);

            if (_agent2D.GroundDetector.IsGrounded)
                _agent2D.RigidBody2D.velocity = Vector2.zero;
        }

        public override void StateUpdate() {
            // Prevent Update Method While Attacking
        }

        public override void StateFixedUpdate() {
            // Prevent Fixed Update Method While Attacking
        }

        public override void Agent2DState_OnAnimationEvent() {
            InvokeAttack();
        }

        public override void Agent2DState_OnAnimationEndEvent() {
            ChangeStateToIdle();
        }

        public override void Exit() {
            base.Exit();
            _agent2D.AgentWeapon.ToggleWeaponVisibility(false);
            _agent2D.Animator.onAnimationEvent -= InvokeAttack;
            _agent2D.Animator.onAnimationEndEvent -= ChangeStateToIdle;
        }
    }
}