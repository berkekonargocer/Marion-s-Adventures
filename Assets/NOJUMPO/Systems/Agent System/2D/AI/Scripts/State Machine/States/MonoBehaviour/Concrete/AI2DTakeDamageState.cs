using Nojumpo.AgentSystem;

namespace Nojumpo
{
    public class AI2DTakeDamageState : AI2DState
    {
        // -------------------------------- FIELDS ---------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void OnAnimationEndEvent() {
            _ai2DStateMachine.TransitionToPreviousState();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}