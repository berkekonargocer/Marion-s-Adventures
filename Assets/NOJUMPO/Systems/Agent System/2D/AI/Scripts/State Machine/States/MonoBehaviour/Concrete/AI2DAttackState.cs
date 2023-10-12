using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DAttackState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------
        protected Vector2 _attackDirection;
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        public override void OnEnterState() {
            base.OnEnterState();

            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;

            if (_playerTransform.position.x > transform.position.x)
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = 1;
            }
            else
            {
                _ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection = -1;
            }

            _ai2DStateMachine.m_Renderer.FaceDirection(_ai2DStateMachine.m_AgentMovementData.HorizontalMovementDirection);
            
            Transform agent2DTransform = _ai2DStateMachine.transform;
            _attackDirection = agent2DTransform.right * (agent2DTransform.localScale.x > 0 ? 1 : -1);
        }

        protected override void OnAnimationEvent() {
            _ai2DStateMachine.m_AgentWeapon.GetCurrentWeapon().PerformAttack(_ai2DStateMachine, _attackDirection);
        }

        protected override void OnAnimationEndEvent() {
            _ai2DStateMachine.ChangeState(_ai2DStateMachine.m_StateFactory.m_Chase);
        }
    }
}