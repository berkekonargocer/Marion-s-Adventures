using Nojumpo.StateMachine;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public abstract class AI2DState : State
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            throw new System.NotImplementedException();
        }

        public override void Tick() {
            throw new System.NotImplementedException();
        }

        public override void FixedTick() {
            throw new System.NotImplementedException();
        }

        public override void OnExitState() {
            throw new System.NotImplementedException();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}