using Nojumpo.AgentSystem;
using UnityEngine;

namespace Nojumpo
{
    public class AI2DTakeDamageState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _ai2DStateMachine.m_Rigidbody2D.velocity = Vector2.zero;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void OnAnimationEndEvent() {
            _ai2DStateMachine.TransitionToPreviousState();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}