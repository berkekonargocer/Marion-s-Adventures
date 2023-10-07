using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DAttackState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float damageAmount;
        [SerializeField] DamageTypeSO damageType;

        [SerializeField] LayerMask playerLayerMask;
        [SerializeField] float playerCheckRayLength = 1.00f;

        RaycastHit2D[] forwardCheckHits = new RaycastHit2D[1];

        Transform _playerTransform;
        
        [Space]
        [Header("GIZMOS")]
        [SerializeField] bool showGizmos = true;
        [SerializeField] Color raycastColor = Color.magenta;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------

        void OnDrawGizmos() {
            Gizmos.color = raycastColor;
            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            Gizmos.DrawRay(raycastPosition, objectTransform.right * playerCheckRayLength);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        public override void OnEnterState() {
            base.OnEnterState();
            
            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
            
            _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            
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

        protected override void OnAnimationEvent() {
            TryToDealDamage();
        }

        protected override void OnAnimationEndEvent() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Chase);
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void TryToDealDamage() {
            Transform objectTransform = transform;
            Vector3 raycastPosition = objectTransform.position;
            int forwardHits = Physics2D.RaycastNonAlloc(raycastPosition, objectTransform.right, forwardCheckHits, playerCheckRayLength, playerLayerMask);

            if (forwardHits > 0)
            {
                forwardCheckHits[0].collider.GetComponent<IDamageable>().TakeDamage(damageAmount, damageType);
            }
        }
    }
}