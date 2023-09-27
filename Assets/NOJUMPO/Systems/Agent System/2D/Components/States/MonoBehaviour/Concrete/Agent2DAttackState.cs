using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.AgentSystem
{
    public class Agent2DAttackState : Agent2DStateBase
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Agent2DIdleState idleState;
        [SerializeField] LayerMask damageableLayerMask;
        public UnityEvent<AudioClip> OnWeaponAttack;

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
        void PerformAttack() {
            _agent2D.Animator.onAnimationEvent -= PerformAttack;
            _agent2D.AgentWeapon.GetCurrentWeapon().DealDamage(_agent2D, damageableLayerMask, _attackDirection);
            OnWeaponAttack?.Invoke(_agent2D.AgentWeapon.GetCurrentWeapon().WeaponData.AttackSFX);
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


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Enter() {
            base.Enter();
            _agent2D.Animator.onAnimationEvent += PerformAttack;
            _agent2D.Animator.onAnimationEndEvent += ChangeStateToIdle;
            _agent2D.AgentWeapon.ToggleWeaponVisibility(true);

            Transform agent2DTransform = _agent2D.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);

            if (_agent2D.GroundDetector.IsGrounded)
                _agent2D.RigidBody2D.velocity = Vector2.zero;
        }

        public override void Exit() {
            base.Exit();
            _agent2D.AgentWeapon.ToggleWeaponVisibility(false);
            _agent2D.Animator.onAnimationEvent -= PerformAttack;
            _agent2D.Animator.onAnimationEndEvent -= ChangeStateToIdle;
        }
    }
}