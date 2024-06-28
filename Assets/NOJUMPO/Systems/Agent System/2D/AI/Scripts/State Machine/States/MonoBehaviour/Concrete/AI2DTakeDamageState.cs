using UnityEngine;

namespace NOJUMPO.AgentSystem
{
    public class AI2DTakeDamageState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
            
            if (_ai2DStateMachine.m_AgentDamageable.DamageableHealth.CurrentHealth > 0)
            {
                StartCoroutine(TransitionToPatrolCoroutine(0.1f));
            }
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}